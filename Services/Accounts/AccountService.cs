using Domain.Accounts;
using Domain.Services;
using Services.Accounts.Repositories;

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
}
