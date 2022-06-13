using DynamicWebPanel.Business.DTOs.Departments;
using DynamicWebPanel.Business.Queries.Departments;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Departments;

public class DepartmentsQueryGetAllHandler : IRequestHandler<DepartmentsGetAllQuery, IReadOnlyList<DepartmentsListDto>>
{
    private readonly IDepartmentsRepository _departmentsRepository;

    public DepartmentsQueryGetAllHandler(IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }

    public async Task<IReadOnlyList<DepartmentsListDto>> Handle(DepartmentsGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _departmentsRepository.GetAllAsync<DepartmentsListDto>();
    }
}
