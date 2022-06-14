using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Repository.Abstractions;

public interface IRefreshTokenRepository
{
    public Task AddAsync(RefreshTokens refreshToken);

    public Task UpdateAsync(RefreshTokens refreshToken);

    public Task<RefreshTokens> GetByTokenAsync(string Token);

    public Task<RefreshTokens> GetByUserIDAsync(int ID);

    public Task<RefreshTokens> GetByDeviceAsync(string device);

    public Task DeleteAsync(int id);
}
