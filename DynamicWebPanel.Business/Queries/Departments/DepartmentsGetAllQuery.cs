using DynamicWebPanel.Business.DTOs.Departments;
using MediatR;

namespace DynamicWebPanel.Business.Queries.Departments;

public class DepartmentsGetAllQuery : IRequest<IReadOnlyList<DepartmentsListDto>> { }