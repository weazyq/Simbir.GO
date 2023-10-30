using Domain.Transports;
using EF.Entities;
using Tools.EnumHelper;

namespace Services.Transports.Converters;
public static class TransportConverter
{
    public static Transport ToDomain(this TransportEntity entity)
    {
        return new Transport(entity.Id, entity.OwnerId, entity.CanBeRented, EnumHelper.GenEnum<TransportType>(entity.TransportType), entity.Model,
            entity.Color, entity.Identifier, entity.Description, entity.Latitude, entity.Longitude, entity.MinutePrice, entity.DayPrice);
    }
}
