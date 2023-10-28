namespace Domain.Transports
{
    public class Transport
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

        public Transport(Int64 id, Int64 ownerId, Boolean canBeRented, TransportType transportType, String model, String color,
            String identifier, String description, Decimal latitude, Decimal longitude, Decimal minutePirce, String dayPrice)
        {
            ID = id;
            OwnerId = ownerId;
            CanBeRented = canBeRented;
            TransportType = transportType;
            Model = model;
            Color = color;
            Identifier = identifier;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            MinutePirce = minutePirce;
            DayPrice = dayPrice;
        }
    }
}
