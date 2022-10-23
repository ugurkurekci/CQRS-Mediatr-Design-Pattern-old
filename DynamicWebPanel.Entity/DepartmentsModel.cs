using System.ComponentModel.DataAnnotations;

namespace DynamicWebPanel.Entity;

public class DepartmentsModel
{

    [Key]
    public int ID { get; set; }

    public string DepartmentsName { get; set; }

    public DateTime CreateDate { get; set; }

    public ICollection<UsersModel> UsersModel { get; set; }

}