using DynamicWebPanel.Business.DTOs.Departments;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Departments;

public class DepartmentsCommandUpdate : IRequest<int>
{

    public int ID { get; set; }

    public DepartmentsUpdateDto DepartmentsUpdateDto { get; set; }

    public DepartmentsCommandUpdate(DepartmentsUpdateDto departmentsUpdateDto, int id)
    {
        DepartmentsUpdateDto = departmentsUpdateDto;
        ID = id;
    }

}