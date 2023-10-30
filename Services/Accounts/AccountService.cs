using Domain.Accounts;
using Domain.Services;
using Services.Accounts.Repositories;
using Tools.Encryption;
using Tools.Result;

namespace Services.Accounts;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Account? GetAccount(String username)
    {
        return _accountRepository.GetAccount(username);
    }

    public Result SignUp(String username, String password) 
    {
        Account? account = GetAccount(username);
        if (account is not null) return Result.Fail($"Аккаунт с логином {username} уже зарегистрирован в системе");

        return _accountRepository.SignUp(username, password);
    }

    public Result Update(String userName, String password)
    {
        Account? account = GetAccount(userName);
        if (account is null) return Result.Fail($"Аккаунт с логином {userName} удалён или не существует");

        account.UserName = userName;
        account.Password = HashPasswordTool.HashPassword(password);

        return _accountRepository.Update(account);
    }
}
