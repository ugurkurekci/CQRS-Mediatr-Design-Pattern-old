using AutoMapper;
using DynamicWebPanel.Business.Commands.Users;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Users;

public class UsersCommandCreateHandler : IRequestHandler<UsersCommandCreate, int>
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersCommandCreateHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(UsersCommandCreate request, CancellationToken cancellationToken)
    {
        UsersModel usersModel = _mapper.Map<UsersModel>(request._usersCreateDto);
        await _userRepository.AddAsync(usersModel);
        return await Task.FromResult(usersModel.ID);
    }

}