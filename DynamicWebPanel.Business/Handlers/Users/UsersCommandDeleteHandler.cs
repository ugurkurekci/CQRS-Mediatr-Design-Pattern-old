using DynamicWebPanel.Business.Commands.Users;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Users;

public class UsersCommandDeleteHandler : IRequestHandler<UsersCommandDelete, int>
{

    private readonly IUserRepository _userRepository;

    public UsersCommandDeleteHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(UsersCommandDelete request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.ID);
        return request.ID;
    }

}