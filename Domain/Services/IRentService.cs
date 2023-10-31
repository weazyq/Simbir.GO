using Domain.Rents;
using Tools.Result;

namespace Domain.Services;
public interface IRentService
{
    public DataResult<Rent> Info(Int64 rentId, Int64 userId);
    public Rent[] GetAccountRentHistory(Int64 userId);
    public DataResult<Rent[]> GetTransportRentHistory(Int64 transportId, Int64 userId);
}
