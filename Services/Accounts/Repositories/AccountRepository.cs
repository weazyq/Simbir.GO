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

    public Account? GetAccount(Int64 accountId)
    {
        return _dbRepository.Get<AccountEntity>(e => e.Id == accountId).FirstOrDefault()?.ToDomain();
    }

    public Result SignUp(String username, String password)
    {
        AccountEntity account = new()
        {
            UserName = username,
            Password = password
        };

        try
        {
            _dbRepository.Add(account);
            _dbRepository.SaveChanges();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Fail("Не удалось сохранить аккаунт");
        }
    }

    public Result Update(Account account)
    {
        try
        {
            AccountEntity accountEntity = _dbRepository.Get<AccountEntity>(e => e.Id == account.Id).First();

            accountEntity.UserName = account.UserName;
            accountEntity.Password = account.Password;

            _dbRepository.Update(accountEntity);
            _dbRepository.SaveChanges();
            return Result.Success();
        } 
        catch (Exception ex)
        {
            return Result.Fail("Ошибка обновления данных о пользователе");
        }
    }
}
