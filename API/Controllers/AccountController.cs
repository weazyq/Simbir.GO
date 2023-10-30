using API.Tools;
using Domain.Accounts;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tools.Encryption;
using Tools.Result;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly JWTSettings _options;
    private readonly IAccountService _accountsService;

    public AccountController(IOptions<JWTSettings> options, IAccountService accountsService)
    {
        _options = options.Value;
        _accountsService = accountsService;
    }

    [Authorize]
    [HttpGet("Me")]
    public Account? Info()
    {
        var user = User;

        Account? account = _accountsService.GetAccount(User.Identity.Name);
        if (account is null) return null;

        return account;
    }

    public record SignInRequest(String UserName, String Password);
    [HttpPost("SignIn")]
    public DataResult<String> SignIn([FromBody] SignInRequest request)
    {
        Account? account = _accountsService.GetAccount(request.UserName);
        if (account is null) return DataResult<String>.Fail($"Не удалось найти аккаунт с логином {request.UserName} в системе");
        if (account.Password != HashPasswordTool.HashPassword(request.Password)) return DataResult<String>.Fail("Вы указали неверный пароль");

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, account.UserName),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim("Id", $"{account.Id}"),
        };

        //срок действия токена
        DateTime startDateTime = DateTime.UtcNow;
        DateTime expireDateTime = DateTime.UtcNow.Add(TimeSpan.FromHours(3));

        SymmetricSecurityKey signingKey = JWTTools.FormSingingKey(_options.SecretKey);
        SigningCredentials credentials = new(signingKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(_options.Issuer, _options.Audience, claims, startDateTime, expireDateTime, credentials);
        return DataResult<String>.Success(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public record SignUpRequest(String UserName, String Password);
    [HttpPost("SignUp")]
    public Result SignUp([FromBody] SignUpRequest request)
    {
        return _accountsService.SignUp(request.UserName, HashPasswordTool.HashPassword(request.Password));
    }

    public record UpdateRequest(String UserName, String Password);
    [Authorize]
    [HttpPut("Update")]
    public Result Update([FromBody] UpdateRequest request)
    {
        return _accountsService.Update(request.UserName, request.Password);
    }
}
