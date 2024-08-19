using API_Entrance.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Entrance.Core.Entities.Concrete
{
    public class TaskItem : BaseEntity
    {
        private bool? _isCompleted = false;

        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public bool? IsCompleted { get => _isCompleted; set => _isCompleted = value; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
