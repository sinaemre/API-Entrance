using API_Entrance.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace API_Entrance.Core.Entities.Concrete
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
