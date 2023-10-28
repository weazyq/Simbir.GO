namespace EF.Entities
{
    public class RentEntity
    {
        public Int64 Id { get; set; }
        public Int64 TransportId { get; set; }
        public Int64 UserId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Decimal PriceOfUnit { get; set; }
        public Int32 PriceType { get; set; }
        public Decimal FinalPrice { get; set; }
    }
}
