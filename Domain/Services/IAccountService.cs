using Domain.Accounts;

namespace Domain.Services;
public interface IAccountService
{
    public Account? GetAccount(String username);
}
