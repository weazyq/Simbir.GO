using Domain.Accounts;
using EF.Entities;
using EF.Repositories;
using Services.Accounts.Converters;

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
}
