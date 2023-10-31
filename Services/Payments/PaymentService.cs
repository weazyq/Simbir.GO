using Domain.Accounts;
using Domain.Services;
using Services.Accounts.Repositories;
using Services.Payments.Repositorie;
using Tools.Result;

namespace Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IAccountRepository _accountRepository;
    public PaymentService(IPaymentRepository paymentRepository, IAccountRepository accountRepository)
    {
        _paymentRepository = paymentRepository;
        _accountRepository = accountRepository; 
    }

    public Result Hesoyam(Int64 accountId, Int64 userId, Boolean isAdmin)
    {
        Account? account = _accountRepository.GetAccount(accountId);
        if (account is null) return Result.Fail("Указанный Вами аккаунт не найден");
        if (!isAdmin && userId != accountId) return Result.Fail("У Вас нет доступа на изменение баланса других пользователей");
        return _paymentRepository.Hesoyam(accountId);
    }
}
