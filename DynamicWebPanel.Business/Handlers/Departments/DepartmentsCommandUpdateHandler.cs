using AutoMapper;
using DynamicWebPanel.Business.Commands.Departments;
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

    public Task<int> Handle(DepartmentsCommandUpdate request, CancellationToken cancellationToken)
    {
        //check user id
        //exist map
        //return request.ID
        throw new NotImplementedException();
    }
}