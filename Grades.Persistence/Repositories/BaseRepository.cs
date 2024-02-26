using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Inspector.Persistence.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly ApplicationDbContext Context;

		public BaseRepository(ApplicationDbContext context)
		{
			Context = context;
		}

		public async Task CreateAsync(T entity)
		{
            Log.Information("Creating item with id: {Id}", entity.Id);
            await Context.AddAsync(entity);
            Log.Information("Item created successfully with id: {Id}", entity.Id);
        }

		public async Task UpdateAsync(T entity)
		{
            Log.Information("Updating item with id: {Id}", entity.Id);
            Context.Update(entity);
            Log.Information("Item updated successfully with id: {Id}", entity.Id);
        }

		public async Task DeleteAsync(T entity)
		{
            Log.Information("Delating item with id: {Id}", entity.Id);
            Context.Remove(entity);
            Log.Information("Item deleted successfully with id: {Id}", entity.Id);
        }

		public async Task<T> GetAsync(Guid id, string? includeProperties = null)
		{
            Log.Information("Get item with id: {Id}", id);
            var query = Context.Set<T>().AsQueryable();

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}

			return await query.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<T>> GetAllAsync(string? includeProperties = null)
		{
            Log.Information("Get all items");
            IQueryable<T> query = Context.Set<T>();
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return await query.ToListAsync();
		}
		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
            Log.Information("Item saved successfully");
        }
	}
}
