using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Entrance.Core.DTO.TaskItemDTO
{
    public class CreateTaskItemDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string Description { get; set; }
        
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public DateTime? Deadline { get; set; }
       
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public int? CategoryId { get; set; }
    }
}
