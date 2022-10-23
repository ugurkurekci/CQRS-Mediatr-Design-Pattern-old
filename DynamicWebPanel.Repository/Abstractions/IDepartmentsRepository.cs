using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Repository.Abstractions;
public interface IDepartmentsRepository
{

    public Task<IReadOnlyList<T>> GetAllAsync<T>();

    public Task<DepartmentsModel> GetByID<T>(int ID);

    public Task AddAsync(DepartmentsModel departmentsModel);

    public Task<int> UpdateAsync(DepartmentsModel departmentsModel);

    public Task<int> DeleteAsync(int id);

}