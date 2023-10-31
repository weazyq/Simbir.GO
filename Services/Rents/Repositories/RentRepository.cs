using Domain.Rents;
using EF.Entities;
using EF.Repositories;
using Services.Rents.Converters;

namespace Services.Rents.Repositories;
public class RentRepository : IRentRepository
{
    private readonly IDbRepository _dbRepository;

    public RentRepository(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public Rent? Get(Int64 rentId)
    {
        return _dbRepository.Get<RentEntity>(r => r.Id == rentId).FirstOrDefault()?.ToDomain();
    }

    public Rent[] GetAccountRentHistory(Int64 userId)
    {
        return _dbRepository.Get<RentEntity>(r => r.UserId == userId).ToArray().ToDomain();
    }

    public Rent[] GetTransportRentHistory(Int64 transportId)
    {
        return _dbRepository.Get<RentEntity>(r => r.TransportId == transportId).ToArray().ToDomain();
    }
}
