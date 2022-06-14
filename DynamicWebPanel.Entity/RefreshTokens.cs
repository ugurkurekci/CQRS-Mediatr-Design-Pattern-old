using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicWebPanel.Entity;

public class RefreshTokens
{

    [Key]
    public int ID { get; set; }

    [ForeignKey("UsersModel")]
    public int UserID { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public string Device { get; set; }

    public string IpAdress { get; set; }

    public UsersModel UsersModel { get; set; }

}
