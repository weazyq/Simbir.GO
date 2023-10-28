namespace Domain.Rents;
public class Rent
{
    public Int64 Id { get; set; }
    public Int64 TransportId { get; set; }
    public Int64 UserId { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime TimeEnd { get; set; }
    public Decimal PriceOfUnit { get; set; }
    public Int32 PriceType { get; set; }
    public Decimal FinalPrice { get; set; }

    public Rent(Int64 id, Int64 transportId, Int64 userId, DateTime timeStart, DateTime timeEnd, Decimal priceOfUnit, Int32 priceType, Decimal finalPrice)
    {
        Id = id;
        TransportId = transportId;
        UserId = userId;
        TimeStart = timeStart;
        TimeEnd = timeEnd;
        PriceOfUnit = priceOfUnit;
        PriceType = priceType;
        FinalPrice = finalPrice;
    }
}
