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

    public async Task<IReadOnlyList<T>> GetAllAsync<T>()
    {
        return await _dynamicWebPanelDbContext.Departments.ProjectTo<T>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task AddAsync(DepartmentsModel departmentsModel)
    {
        _dynamicWebPanelDbContext.Departments.Add(departmentsModel);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(DepartmentsModel departmentsModel)
    {
        _dynamicWebPanelDbContext.Departments.Update(departmentsModel);
        return await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = _dynamicWebPanelDbContext.Departments.Single(x => x.ID == id);
        if (entity == null)
        {
            return -1;
        }
        _dynamicWebPanelDbContext.Departments.Remove(entity);
        return await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<DepartmentsModel> GetByID<T>(int ID)
    {
        return await _dynamicWebPanelDbContext.Departments.FirstOrDefaultAsync(x => x.ID == ID);
    }
}