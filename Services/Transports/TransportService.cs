using Domain.Services;
using Domain.Transports;
using Services.Transports.Repositories;
using Tools.Result;

namespace Services.Transports;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _transportRepository;

    public TransportService(ITransportRepository transportRepository) 
    {
        _transportRepository = transportRepository;
    }

    public Result Save(TransportBlank blank, Int64 userId)
    {
        return _transportRepository.Save(blank, userId);
    }

    public Transport? Get(Int64 id)
    {
        return _transportRepository.Get(id);
    }

    public Result Update(Int64 id, TransportBlank blank, Int64 userId)
    {
        Transport? transport = _transportRepository.GetByOwner(userId);
        if (transport is null) return Result.Fail("Указанный Вами транспорт удалён или не найден");

        return _transportRepository.Update(id, blank, userId);
    }

    public Result Delete(Int64 id, Int64 userId)
    {
        Transport? transport = _transportRepository.Get(id);
        if (transport is null) return Result.Fail("Указнный Вами транспорт удалён или не найден");
        if (transport.OwnerId != userId) return Result.Fail("Доступ на удаление транспорта может иметь только его владелец");

        return _transportRepository.Delete(id);
    }
}
