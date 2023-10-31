using Domain.Rents;
using EF.Entities;

namespace Services.Rents.Converters;
public static class RentConverter
{
    public static Rent ToDomain(this RentEntity entity)
    {
        return new Rent(entity.Id, entity.TransportId, entity.UserId, entity.TimeStart, entity.TimeEnd, entity.PriceOfUnit, entity.PriceType,
            entity.FinalPrice);
    }

    public static Rent[] ToDomain(this RentEntity[] entities)
    {
        return entities.Select(e => e.ToDomain()).ToArray();
    }
}
