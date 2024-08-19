using API_Entrance.Core.Entities.Concrete;
using API_Entrance.DataAccess.Context;
using API_Entrance.Services.Interface;

namespace API_Entrance.Services.Concrete
{
    public class CategoryService : BaseRepository<Category>, ICategoryService
    {
        public CategoryService(AppDbContext context) : base(context)
        {
        }
    }
}
