using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicWebPanel.Entity;

public class UsersModel
{

    public int ID { get; set; }

    [ForeignKey("DepartmentsModel")]
    public int DepartmentsID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreateDate { get; set; }

    public DepartmentsModel DepartmentsModel { get; set; }

}