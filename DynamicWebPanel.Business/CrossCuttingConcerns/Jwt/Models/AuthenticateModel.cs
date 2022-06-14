namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;

public class AuthenticateModel
{

    public int UserID { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Device { get; set; }

    public string IpAdress { get; set; }

    public string RefreshToken { get; set; }

}