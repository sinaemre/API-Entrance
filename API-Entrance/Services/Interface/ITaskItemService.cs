using API_Entrance.Core.Entities.Concrete;

namespace API_Entrance.Services.Interface
{
    public interface ITaskItemService : IBaseRepository<TaskItem>
    {
        Task<List<TaskItem>> GetTaskItemsByCategoryId(int categoryId);
    }
}
