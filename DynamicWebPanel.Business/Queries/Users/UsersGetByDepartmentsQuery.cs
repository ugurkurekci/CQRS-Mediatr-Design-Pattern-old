using DynamicWebPanel.Business.DTOs.Users;
using MediatR;

namespace DynamicWebPanel.Business.Queries.Users;

public class UsersGetByDepartmentsQuery: IRequest<IReadOnlyList<UsersListDto>>
{

    public int DepartmentsID { get; set; }

    public UsersGetByDepartmentsQuery(int id)
    {
        DepartmentsID = id;
    }

}