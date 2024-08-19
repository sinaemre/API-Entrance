using API_Entrance.Core.Entities.Concrete;
using API_Entrance.DataAccess.Context;
using API_Entrance.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace API_Entrance.Services.Concrete
{
    public class TaskItemService : BaseRepository<TaskItem>, ITaskItemService
    {
        private readonly AppDbContext _context;

        public TaskItemService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetTaskItemsByCategoryId(int categoryId)
            => await _context.TaskItems.Where(x => x.CategoryId == categoryId).ToListAsync();
    }
}
