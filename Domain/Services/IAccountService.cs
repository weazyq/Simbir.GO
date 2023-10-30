using Domain.Accounts;
using Tools.Result;

namespace Domain.Services;
public interface IAccountService
{
    public Account? GetAccount(String username);
    public Result SignUp(String username, String password);
    public Result Update(String userName, String password);
}
