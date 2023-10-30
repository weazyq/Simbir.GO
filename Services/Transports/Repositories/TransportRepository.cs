using Domain.Transports;
using EF.Entities;
using EF.Repositories;
using Services.Transports.Converters;
using Tools.Result;

namespace Services.Transports.Repositories;

public class TransportRepository : ITransportRepository
{
    private readonly IDbRepository _repository;

    public TransportRepository(IDbRepository repository)
    {
        _repository = repository;
    }
    public Result Save(TransportBlank blank, Int64 userId)
    {
        TransportEntity transportEntity = new()
        {
            OwnerId = userId,
            CanBeRented = blank.CanBeRented,
            TransportType = blank.TransportType,
            Model = blank.Model,
            Color = blank.Color,
            Identifier = blank.Identifier,
            Description = blank.Description,
            Latitude = blank.Latitude,
            Longitude = blank.Longitude,
            MinutePrice = blank.MinutePrice,
            DayPrice = blank.DayPrice,
        };

        try
        {
            _repository.Add(transportEntity);
            _repository.SaveChanges();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Fail("Не удалось сохранить транспорт");
        }
    }

    public Transport? Get(Int64 id)
    {
        return _repository.Get<TransportEntity>(t => t.Id == id).FirstOrDefault()?.ToDomain();
    }
    
    public Transport? GetByOwner(Int64 id)
    {
        return _repository.Get<TransportEntity>(t => t.OwnerId == id).FirstOrDefault()?.ToDomain();
    }

    public Result Update(Int64 id, TransportBlank blank, Int64 userId)
    {
        TransportEntity transportEntity = _repository.Get<TransportEntity>(t => t.Id == id).First();
        if (transportEntity.OwnerId != userId) return Result.Fail("Доступ на редактирование информации о транспорте имеет только его владелец");

        transportEntity.CanBeRented = blank.CanBeRented;
        transportEntity.TransportType = blank.TransportType;
        transportEntity.Model = blank.Model;
        transportEntity.Color = blank.Color;
        transportEntity.Identifier = blank.Identifier;
        transportEntity.Description = blank.Description;
        transportEntity.Latitude = blank.Latitude;
        transportEntity.Longitude = blank.Longitude;

        try
        {
            _repository.Update(transportEntity);
            _repository.SaveChanges();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Fail("Не удалось сохранить изменения транспорта");
        }
    }

    public Result Delete(Int64 id)
    {
        TransportEntity transport = _repository.Get<TransportEntity>(t => t.Id == id).First();
        
        try
        {
            _repository.Delete(transport);
            _repository.SaveChanges();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Fail($"Не удалось удалить указанный Вами адрес");
        }
    }
}
