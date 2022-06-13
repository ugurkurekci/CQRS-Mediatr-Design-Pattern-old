using AutoMapper;
using DynamicWebPanel.Business.Commands.Departments;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Departments;

public class UsersCommandCreateHandler : IRequestHandler<DepartmentsCommandCreate, int>
{
    private readonly IDepartmentsRepository _departmentsRepository;
    private readonly IMapper _mapper;

    public UsersCommandCreateHandler(IDepartmentsRepository departmentsRepository, IMapper mapper)
    {
        _departmentsRepository = departmentsRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(DepartmentsCommandCreate request, CancellationToken cancellationToken)
    {
        DepartmentsModel departmentsModel = _mapper.Map<DepartmentsModel>(request._departmentsCreateDto);
        await _departmentsRepository.AddAsync(departmentsModel);
        return await Task.FromResult(departmentsModel.ID);
    }
}
