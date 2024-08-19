using API_Entrance.Core.DTO.CategoryDTO;
using API_Entrance.Core.Entities.Concrete;
using API_Entrance.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Entrance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        /// <summary>
        /// You can get all categories...
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCategories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();

            if (categories != null)
            {
                var model = _mapper.Map<List<GetCategoryDTO>>(categories);
                return StatusCode(200, model);
            }

            return StatusCode(404, "Herhangi bir kategori bulunamadı!");
        }

        /// <summary>
        /// You can get category by id.
        /// </summary>
        /// <param name="id">Id is required field.</param>
        /// <returns></returns>
        [HttpGet("GetCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id)
        {
            if (id <= 0)
                return StatusCode(400, "Id bilgisi hatalıdır!");

            var category = await _categoryService.GetByIdAsync(id);

            if (category != null)
            {
                var model = _mapper.Map<GetCategoryDTO>(category);
                return StatusCode(200, model);
            }

            return StatusCode(404, "Kategori bulunamadı!");
        }

        /// <summary>
        /// You can create category.
        /// </summary>
        /// <param name="model">Name field is required!</param>
        /// <returns></returns>
        [HttpPost("CreateCategory")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            if (model == null)
                return StatusCode(400, "Hatalı istek!");

            var category = _mapper.Map<Category>(model);

            if (category != null)
            {
                var result = await _categoryService.AddAsync(category);
                if (result)
                    return StatusCode(201, "Kategori eklenmiştir!");

            }
            return StatusCode(500, "Kategori eklenememiştir!");
        }

        /// <summary>
        /// You can update category.
        /// </summary>
        /// <param name="model">Name field is required.</param>
        /// <returns></returns>
        [HttpPut("UpdateCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDTO model)
        {
            if (model == null)
                return StatusCode(400, "Hatalı istek!");

            var category = await _categoryService.GetByIdAsync(model.Id);

            if (category == null)
                return StatusCode(404, "Kategori bulunamadı!");

            _mapper.Map(model, category);

            var result = await _categoryService.UpdateAsync(category);
            if (result)
                return StatusCode(200, "Kategori güncellenmiştir!");

            return StatusCode(500, "Kategori güncellenemedi!");
        }

        /// <summary>
        /// You can delete category by id.
        /// </summary>
        /// <param name="id">Id field is required!</param>
        /// <returns></returns>
        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteCategory([FromQuery]int id)
        {
            if (id <= 0)
                return StatusCode(400, "Geçersiz id bilgisi!");

            var category = await _categoryService.GetByIdAsync(id);

            if (category != null)
            {
                var result = await _categoryService.DeleteAsync(category);
                if (result)
                    return StatusCode(200, "Kategori silinmiştir!");

                return StatusCode(500, "Kategori silinememiştir!");
            }

            return StatusCode(404, "Kategori bulunamamıştır!");
        }
    }
}
