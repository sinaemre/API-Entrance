using API_Entrance.Core.Entities.Abstract;

namespace API_Entrance.Services.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
