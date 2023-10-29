using Domain.Accounts;
using EF.Entities;

namespace Services.Accounts.Converters;

public static class AccountConverter
{
    public static Account ToDomain(this AccountEntity account)
    {
        return new Account(account.Id, account.UserName, account.Password, account.IsAdmin, account.Balance);
    }
}
