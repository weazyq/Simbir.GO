namespace API.Tools;

public class JWTSettings
{
    public String SecretKey { get; set; }
    public String Issuer { get; set; }
    public String Audience { get; set; }
}
