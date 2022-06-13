using AutoMapper;
using AutoMapper.QueryableExtensions;
using DynamicWebPanel.Data;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DynamicWebPanel.Repository.Concretes;

public class DepartmentsRepository : IDepartmentsRepository
{
    private readonly DynamicWebPanelDbContext _dynamicWebPanelDbContext;
    private readonly IMapper _mapper;

    public DepartmentsRepository(DynamicWebPanelDbContext dynamicWebPanelDbContext, IMapper mapper)
    {
        _dynamicWebPanelDbContext = dynamicWebPanelDbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(DepartmentsModel departmentsModel)
    {
        _dynamicWebPanelDbContext.Departments.Add(departmentsModel);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = _dynamicWebPanelDbContext.Departments.Single(x => x.ID == id);
        _dynamicWebPanelDbContext.Departments.Remove(entity);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync<T>()
    {
        return await _dynamicWebPanelDbContext.Departments.ProjectTo<T>(_mapper.ConfigurationProvider).ToListAsync();
    }
}