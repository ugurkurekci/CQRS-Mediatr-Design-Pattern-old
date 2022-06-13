using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Repository.Abstractions;
public interface IUserRepository
{

    public Task AddAsync(UsersModel usersModel);

    public Task<IReadOnlyList<T>> GetAllAsync<T>();

    public Task DeleteAsync(int id);

    public Task<IReadOnlyList<T>> GetAsync<T>(int DepartmentsID);

}