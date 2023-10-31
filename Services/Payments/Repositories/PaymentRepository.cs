using Domain.Accounts;
using EF.Entities;
using EF.Repositories;
using Services.Payments.Repositorie;
using Tools.Result;

namespace Services.Payments.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private readonly IDbRepository _dbRepository;

    public PaymentRepository(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public Result Hesoyam(Int64 accountId)
    {
        AccountEntity? account = _dbRepository.Get<AccountEntity>(a => a.Id == accountId).FirstOrDefault();
        if (account is null) return Result.Fail("Указанный Вами аккаунт удалён или не существует");

        try
        {
            account.Balance += 250000;
            _dbRepository.Update(account);
            _dbRepository.SaveChanges();
            return Result.Success();

        }
        catch (Exception)
        {
            return Result.Fail("Не удалось выдать на баланс аккаунта деньги");
        }
    }
}
