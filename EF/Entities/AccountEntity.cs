namespace EF.Entities
{
    public class AccountEntity
    {
        public Int64 Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean IsAdmin { get; set; }
        public Decimal Balance { get; set; }
    }
}
