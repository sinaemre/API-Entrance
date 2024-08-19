using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Entrance.Core.DTO.TaskItemDTO
{
    public class UpdateTaskItemDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }

        public int? CategoryId { get; set; }
    }
}
