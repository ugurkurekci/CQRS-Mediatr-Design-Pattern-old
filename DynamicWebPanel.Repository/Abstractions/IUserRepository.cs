using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Repository.Abstractions;
public interface IUserRepository
{

    public Task<IReadOnlyList<T>> GetAllAsync<T>();

    public Task<IReadOnlyList<T>> GetAsync<T>(int DepartmentsID);

    public Task AddAsync(UsersModel usersModel);

    public Task<int> UpdateAsync(UsersModel usersModel);

    public Task<int> DeleteAsync(int id);

    public Task<UsersModel> GetByEmailAsync(string Email);

    public Task<UsersModel> GetCheckEmailPassword(string email, string password);

}