using DynamicWebPanel.Business.DTOs.Users;
using MediatR;

namespace DynamicWebPanel.Business.Queries.Users;

public class UsersGetAllQuery : IRequest<IReadOnlyList<UsersListDto>> { }

