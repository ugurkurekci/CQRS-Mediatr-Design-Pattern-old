using MediatR;

namespace DynamicWebPanel.Business.Commands.Departments;

public class DepartmentsCommandDelete : IRequest<int>
{

    public int ID { get; set; }

    public DepartmentsCommandDelete(int id)
    {
        ID = id;
    }

}