using AutoMapper;
using DynamicWebPanel.Business.Commands.Users;
using DynamicWebPanel.Entity;
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

    public async Task<int> Handle(UsersCommandUpdate request, CancellationToken cancellationToken)
    {

        int userID = request.ID;
        UsersModel exist = await _userRepository.GetAsyncByID<UsersModel>(request.ID);
        UsersModel usersModel = _mapper.Map(request.UsersUpdateDto, exist);
        int result = await _userRepository.UpdateAsync(usersModel);
        return result;
    }
}
