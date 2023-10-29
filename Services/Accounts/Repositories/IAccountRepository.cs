using Domain.Accounts;
using System.Security.Principal;

namespace Services.Accounts.Repositories;
public interface IAccountRepository
{
    public Account? GetAccount(String username);
}
