using DynamicWebPanel.Business.DTOs.Users;
using DynamicWebPanel.Business.Queries.Users;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Users;

public class UsersQueryGetByDepartmentsHandler : IRequestHandler<UsersGetByDepartmentsQuery, IReadOnlyList<UsersListDto>>
{

    private readonly IUserRepository _userRepository;

    public UsersQueryGetByDepartmentsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<UsersListDto>> Handle(UsersGetByDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAsync<UsersListDto>(request.DepartmentsID);

    }

}