namespace Grades.Application.IRepositories
{
	public interface IBaseRepository<T> where T: class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Guid id, string? includeProperties = null);
        Task<List<T>> GetAllAsync(string? includeProperties = null); 
        Task SaveAsync();
    }
}
