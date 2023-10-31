using Tools.Result;

namespace Domain.Services;
public interface IPaymentService
{
    public Result Hesoyam(Int64 accountId, Int64 userId, Boolean isAdmin);
}
