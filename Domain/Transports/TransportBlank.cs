namespace Domain.Transports;

public record TransportBlank(Boolean CanBeRented, String TransportType, String Model, String Color, String Identifier, String? Description, 
    Double Latitude, Double Longitude, Decimal? MinutePrice, Decimal? DayPrice);
