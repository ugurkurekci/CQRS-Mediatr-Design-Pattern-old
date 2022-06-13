namespace DynamicWebPanel.Business.DTOs.Users;

public class UsersCreateDto
{

    public int DepartmentsID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

}