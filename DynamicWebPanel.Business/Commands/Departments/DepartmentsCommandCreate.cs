using DynamicWebPanel.Business.DTOs.Departments;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Departments;

public class DepartmentsCommandCreate : IRequest<int>
{

    public DepartmentsCreateDto _departmentsCreateDto;

    public DepartmentsCommandCreate(DepartmentsCreateDto departmentsCreateDto)
    {
        _departmentsCreateDto = departmentsCreateDto;
    }

}