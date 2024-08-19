using API_Entrance.Core.DTO.TaskItemDTO;
using API_Entrance.Core.Entities.Concrete;
using API_Entrance.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Entrance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IMapper _mapper;

        public TaskItemsController(ITaskItemService taskItemService, IMapper mapper)
        {
            _taskItemService = taskItemService;
            _mapper = mapper;
        }

        [HttpGet("GetTaskItems")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllTaskItems()
        {
            var taskItems = await _taskItemService.GetAllAsync();

            if (taskItems != null)
            {
                var model = _mapper.Map<List<GetTaskItemDTO>>(taskItems);
                return StatusCode(200, model);
            }

            return StatusCode(404, "Görev bulunamadı!");
        }

        [HttpGet("GetTaskItemsByCategoryId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTaskItemsByCategoryId([FromQuery]int categoryId)
        {
            var taskItems = await _taskItemService.GetTaskItemsByCategoryId(categoryId);

            if (taskItems != null)
            {
                var model = _mapper.Map<List<GetTaskItemDTO>>(taskItems);
                return StatusCode(200, model);
            }

            return StatusCode(404, "Görev bulunamadı!");
        }

        [HttpPost("CreateTaskItem")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateTaskItem([FromForm]CreateTaskItemDTO model)
        {
            if (model == null)
                return StatusCode(400, "Hatalı istek!");

            var taskItem = _mapper.Map<TaskItem>(model);

            if (taskItem != null)
            {
                var result = await _taskItemService.AddAsync(taskItem);
                if (result)
                    return StatusCode(201, "Görev eklenmiştir!");

                return StatusCode(500, "Görev eklenememiştir!");
            }

            return StatusCode(404, "Görev bulunamadı!");
        }

        [HttpPut("UpdateTaskItem")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTaskItem([FromForm]UpdateTaskItemDTO model)
        {
            if (model == null)
                return StatusCode(400, "Hatalı istek!");

            var taskItem = await _taskItemService.GetByIdAsync(model.Id);

            if (taskItem == null)
                return StatusCode(404, "Görev bulunamadı!");

            _mapper.Map(model, taskItem);

            var result = await _taskItemService.UpdateAsync(taskItem);

            if (result)
                return StatusCode(200, "Görev güncellendi!");

            return StatusCode(500, "Görev güncellenemedi!");
        }

        [HttpDelete("DeleteTaskItem")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTaskItem([FromQuery]int id)
        {
            if (id <= 0)
                return StatusCode(400, "Geçersiz Id bilgisi!");

            var taskItem = await _taskItemService.GetByIdAsync(id);

            if (taskItem != null)
            {
                var result = await _taskItemService.DeleteAsync(taskItem);
                if (result)
                    return StatusCode(200, "Görev silinmiştir!");

                return StatusCode(500, "Görev silinememiştir!");
            }

            return StatusCode(404, "Görev bulunamadı!");
        }
    }
}
