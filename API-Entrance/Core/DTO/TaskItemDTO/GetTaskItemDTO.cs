using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Entrance.Core.DTO.TaskItemDTO
{
    public class GetTaskItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsCompleted { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}
