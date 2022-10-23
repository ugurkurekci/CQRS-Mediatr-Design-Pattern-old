using DynamicWebPanel.Business.DTOs.Users;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Users;

public class UsersCommandCreate : IRequest<int>
{

    public UsersCreateDto _usersCreateDto;

    public UsersCommandCreate(UsersCreateDto usersCreateDto)
    {
        _usersCreateDto = usersCreateDto;
    }

}