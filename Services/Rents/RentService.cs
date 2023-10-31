using Domain.Rents;
using Domain.Services;
using Domain.Transports;
using Services.Rents.Repositories;
using Services.Transports.Repositories;
using Tools.Result;

namespace Services.Rents;

public class RentService : IRentService
{
    private readonly IRentRepository _rentRepository;
    private readonly ITransportRepository _transportRepository;

    public RentService(IRentRepository rentRepository, ITransportRepository transportRepository)
    {
        _transportRepository = transportRepository;
        _rentRepository = rentRepository;
    }

    public DataResult<Rent> Info(Int64 rentId, Int64 userId)
    {
        Rent? rent = _rentRepository.Get(rentId);
        if (rent is null) return DataResult<Rent>.Fail("Информация о указанной Вами аренде удалена или не существует");
        Transport? transport = _transportRepository.Get(rent.TransportId);
        if (rent.UserId != userId || transport?.OwnerId != userId) return DataResult<Rent>.Fail("Просмотр информации об аренде доступен только арендатору и владельцу транспорта");

        return DataResult<Rent>.Success(rent);
    }

    public Rent[] GetAccountRentHistory(Int64 userId)
    {
        return _rentRepository.GetAccountRentHistory(userId);
    }

    public DataResult<Rent[]> GetTransportRentHistory(Int64 transportId, Int64 userId)
    {
        Transport? transport = _transportRepository.Get(transportId);
        if (transport is null) return DataResult<Rent[]>.Fail("Указанный Вами транспорт не существует или удалён");
        if (transport.OwnerId != userId) return DataResult<Rent[]>.Fail("Вы должны владеть транспортом, для просмотра истории его аренды");

        Rent[] rents = _rentRepository.GetTransportRentHistory(transportId);
        return DataResult<Rent[]>.Success(rents);
    }
}
