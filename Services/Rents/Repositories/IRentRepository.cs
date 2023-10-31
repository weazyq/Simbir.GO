using Domain.Rents;

namespace Services.Rents.Repositories;
public interface IRentRepository
{
    public Rent? Get(Int64 rentId);
    public Rent[] GetAccountRentHistory(Int64 userId);
    public Rent[] GetTransportRentHistory(Int64 transportId);
}
