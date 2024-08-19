using API_Entrance.Core.Entities.Abstract;
using API_Entrance.DataAccess.Context;
using API_Entrance.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace API_Entrance.Services.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Status.Modified;
            _table.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status = Status.Passive;
            _table.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAllAsync()
            => await _table.Where(x => x.Status != Status.Passive).ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _table.FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Passive);

        
    }
}
