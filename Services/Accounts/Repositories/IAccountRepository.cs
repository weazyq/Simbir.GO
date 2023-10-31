using Domain.Accounts;
using Tools.Result;

namespace Services.Accounts.Repositories;
public interface IAccountRepository
{
    public Account? GetAccount(String username);
    public Account? GetAccount(Int64 accountId);
    public Result SignUp(String username, String password);
    public Result Update(Account account);
}
