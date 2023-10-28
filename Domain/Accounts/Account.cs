namespace Domain.Accounts;

public class Account
{
	public Int64 Id { get; set; }
	public String UserName { get; set; }
	public String Password { get; set; }
	public Boolean IsAdmin { get; set; }
	public Decimal Balance { get; set; }

	public Account(Int64 id, String userName, String password, Boolean isAdmin, Decimal balance)
	{
		Id = id;
		UserName = userName;
		Password = password;
		IsAdmin = isAdmin;
		Balance = balance;
	}
}