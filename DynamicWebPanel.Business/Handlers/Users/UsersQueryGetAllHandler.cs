using DynamicWebPanel.Business.DTOs.Users;
using DynamicWebPanel.Business.Queries.Users;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Users;

public class UsersQueryGetAllHandler : IRequestHandler<UsersGetAllQuery, IReadOnlyList<UsersListDto>>
{

    private readonly IUserRepository _userRepository;

    public UsersQueryGetAllHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<UsersListDto>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync<UsersListDto>();
    }

}