using Microsoft.EntityFrameworkCore;
using MyApp1.Domain.Interfaces;
using MyApp1.Infrastructure.Data;

namespace MyApp1.Infrastructure.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly AppDbContext _ctx;
    private readonly DbSet<T> _db;

    public GenericRepository(AppDbContext ctx)
    {
      _ctx = ctx;
      _db = ctx.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
      await _db.AddAsync(entity);
      await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var entity = await _db.FindAsync(id);
      if (entity == null) return;
      _db.Remove(entity);
      await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _db.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await _db.FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
      _db.Update(entity);
      await _ctx.SaveChangesAsync();
    }
  }
}
