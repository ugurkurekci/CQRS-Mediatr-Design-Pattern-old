using AutoMapper;
using DynamicWebPanel.Business.Commands.Users;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Users;

public class UsersCommandUpdateHandler : IRequestHandler<UsersCommandUpdate, int>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UsersCommandUpdateHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<int> Handle(UsersCommandUpdate request, CancellationToken cancellationToken)
    {
        //check user id
        //exist map
        //return request.ID
        throw new NotImplementedException();
    }
}
