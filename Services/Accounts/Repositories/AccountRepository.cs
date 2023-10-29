using Domain.Accounts;
using EF.Entities;
using EF.Repositories;
using Services.Accounts.Converters;
using Tools.Result;

namespace Services.Accounts.Repositories;
public class AccountRepository : IAccountRepository
{
    private readonly IDbRepository _dbRepository;
    public AccountRepository(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public Account? GetAccount(String username)
    {
        return _dbRepository.Get<AccountEntity>(e => e.UserName == username).FirstOrDefault()?.ToDomain();
    }

    public Result SignUp(String username, String password)
    {
        AccountEntity account = new AccountEntity
        {
            UserName = username,
            Password = password
        };

        try
        {
            _dbRepository.Add<AccountEntity>(account);
            _dbRepository.SaveChanges();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Fail("Не удалось сохранить аккаунт");
        }
    }
}
