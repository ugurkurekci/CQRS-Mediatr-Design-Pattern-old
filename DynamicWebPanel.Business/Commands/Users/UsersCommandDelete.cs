using MediatR;

namespace DynamicWebPanel.Business.Commands.Users;

public class UsersCommandDelete : IRequest<int>
{
    public int ID { get; set; }

    public UsersCommandDelete(int id)
    {
        ID = id;
    }
}
