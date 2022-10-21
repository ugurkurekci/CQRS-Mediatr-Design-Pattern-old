using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicWebPanel.Business.DTOs.Users;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Users;

public class UsersCommandUpdate : IRequest<int>
{

    public int ID { get; set; }
    public UsersUpdateDto UsersUpdateDto { get; set; }

    public UsersCommandUpdate(int id, UsersUpdateDto usersUpdateDto)
    {
        ID = id;
        UsersUpdateDto = usersUpdateDto;
    }

   
}