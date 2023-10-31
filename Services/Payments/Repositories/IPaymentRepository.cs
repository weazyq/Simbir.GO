using Tools.Result;

namespace Services.Payments.Repositorie;

public interface IPaymentRepository
{
    public Result Hesoyam(Int64 accountId);
}
