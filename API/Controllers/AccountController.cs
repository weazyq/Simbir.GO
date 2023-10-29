using API.Tools;
using Domain.Accounts;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

    public record SignInRequest(String UserName, String Password);
    [HttpPost("SignIn")]
    public String SignIn([FromBody] SignInRequest request)
    {
        Account? account = _accountsService.GetAccount(request.UserName);
        if (account is null) return "";

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, account.UserName),
            new Claim(ClaimTypes.Role, "Admin")
        };

        //срок действия токена
        DateTime startDateTime = DateTime.UtcNow;
        DateTime expireDateTime = DateTime.UtcNow.Add(TimeSpan.FromHours(3));

        SymmetricSecurityKey signingKey = JWTTools.FormSingingKey(_options.SecretKey);
        SigningCredentials credentials = new(signingKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(_options.Issuer, _options.Audience, claims, startDateTime, expireDateTime, credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
