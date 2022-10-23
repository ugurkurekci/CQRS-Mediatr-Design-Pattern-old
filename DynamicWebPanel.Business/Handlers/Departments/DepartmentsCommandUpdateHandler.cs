using AutoMapper;
using DynamicWebPanel.Business.Commands.Departments;
using DynamicWebPanel.Business.DTOs.Departments;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Departments;

public class DepartmentsCommandUpdateHandler : IRequestHandler<DepartmentsCommandUpdate, int>
{

    private readonly IMapper _mapper;
    private readonly IDepartmentsRepository _departmentsRepository;

    public DepartmentsCommandUpdateHandler(IMapper mapper, IDepartmentsRepository departmentsRepository)
    {
        _mapper = mapper;
        _departmentsRepository = departmentsRepository;
    }

    public async Task<int> Handle(DepartmentsCommandUpdate request, CancellationToken cancellationToken)
    {
        int userID = request.ID;
        DepartmentsModel exist = await _departmentsRepository.GetByID<DepartmentsUpdateDto>(request.ID);
        DepartmentsModel departmentsModel = _mapper.Map(request.DepartmentsUpdateDto, exist);
        int result = await _departmentsRepository.UpdateAsync(departmentsModel);
        return result;
    }

}