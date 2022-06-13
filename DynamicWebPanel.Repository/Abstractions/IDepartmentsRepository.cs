using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Repository.Abstractions;
public interface IDepartmentsRepository
{

    public Task AddAsync(DepartmentsModel departmentsModel);

    public Task<IReadOnlyList<T>> GetAllAsync<T>();

    public Task DeleteAsync(int id);

}