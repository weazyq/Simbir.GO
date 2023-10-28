using Domain.Transports;

namespace EF.Entities;

public class TransportEntity
{
    public Int64 ID { get; set; }
    public Int64 OwnerId { get; set; }
    public Boolean CanBeRented { get; set; }
    public TransportType TransportType { get; set; }
    public String Model { get; set; }
    public String Color { get; set; }
    public String Identifier { get; set; }
    public String Description { get; set; }
    public Decimal Latitude { get; set; }
    public Decimal Longitude { get; set; }
    public Decimal MinutePirce { get; set; }
    public String DayPrice { get; set; }
}
