using AutoMapper;
using DynamicWebPanel.Data;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DynamicWebPanel.Repository.Concretes;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly DynamicWebPanelDbContext _dynamicWebPanelDbContext;
    private readonly IMapper _mapper;

    public RefreshTokenRepository(DynamicWebPanelDbContext dynamicWebPanelDbContext, IMapper mapper)
    {
        _dynamicWebPanelDbContext = dynamicWebPanelDbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(RefreshTokens refreshToken)
    {
        _dynamicWebPanelDbContext.RefreshTokens.Add(refreshToken);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = _dynamicWebPanelDbContext.RefreshTokens.Single(x => x.ID == id);
        _dynamicWebPanelDbContext.RefreshTokens.Remove(entity);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }

    public async Task<RefreshTokens> GetByDeviceAsync(string device)
    {
        var find = _dynamicWebPanelDbContext.RefreshTokens.FirstOrDefaultAsync(i => i.Device == device);
        return await find;
    }

    public async Task<RefreshTokens> GetByTokenAsync(string Token)
    {
        var find = _dynamicWebPanelDbContext.RefreshTokens.FirstOrDefaultAsync(i => i.RefreshToken == Token);
        return await find;
    }

    public async Task<RefreshTokens> GetByUserIDAsync(int userID)
    {
        var find = _dynamicWebPanelDbContext.RefreshTokens.FirstOrDefaultAsync(i => i.UserID == userID);
        return await find;
    }

    public async Task UpdateAsync(RefreshTokens refreshToken)
    {

        _dynamicWebPanelDbContext.RefreshTokens.Update(refreshToken);
        await _dynamicWebPanelDbContext.SaveChangesAsync();
    }
}
