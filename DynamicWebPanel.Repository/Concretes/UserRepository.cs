using AutoMapper;
using AutoMapper.QueryableExtensions;
using DynamicWebPanel.Data;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DynamicWebPanel.Repository.Concretes;

public class UsersRepository : IUserRepository
{
    private readonly DynamicWebPanelDbContext _dynamicWebPanelDbContext;
    private readonly IMapper _mapper;

    public UsersRepository(DynamicWebPanelDbContext dynamicWebPanelDbContext, IMapper mapper)
    {
        _dynamicWebPanelDbContext = dynamicWebPanelDbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync<T>()
    {
        return await _dynamicWebPanelDbContext.Users.ProjectTo<T>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync<T>(int DepartmentsID)
    {
        return await _dynamicWebPanelDbContext.Users.Where(i => i.DepartmentsID == DepartmentsID).ProjectTo<T>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<UsersModel> GetCheckEmailPassword(string email, string password)
    {
        var find = _dynamicWebPanelDbContext.Users.SingleOrDefaultAsync(i => i.Email == email && i.Password == password);
        return await find;

    }

    public async Task<UsersModel> GetByEmailAsync(string Email)
    {
        var find = _dynamicWebPanelDbContext.Users.FirstOrDefaultAsync(i => i.Email == Email);
        return await find;

    }

    public async Task AddAsync(UsersModel usersModel)
    {
        _dynamicWebPanelDbContext.Users.Add(usersModel);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(UsersModel usersModel)
    {
        _dynamicWebPanelDbContext.Users.Update(usersModel);
        return await _dynamicWebPanelDbContext.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        UsersModel entity = _dynamicWebPanelDbContext.Users.Single(x => x.ID == id);
        if (entity == null)
        {
            return -1;
        }
        _dynamicWebPanelDbContext.Users.Remove(entity);
        return await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<UsersModel> GetAsyncByID<T>(int ID)
    {
        var find = _dynamicWebPanelDbContext.Users.FirstOrDefaultAsync(x => x.ID == ID);
        return await find;

    }
}