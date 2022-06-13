using DynamicWebPanel.Business.Commands.Departments;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Departments;

public class UsersCommandDeleteHandler : IRequestHandler<DepartmentsCommandDelete, int>
{
    private readonly IDepartmentsRepository _departmentsRepository;

    public UsersCommandDeleteHandler(IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }

    public async Task<int> Handle(DepartmentsCommandDelete request, CancellationToken cancellationToken)
    {
        await _departmentsRepository.DeleteAsync(request.ID);
        return request.ID;
    }
}
