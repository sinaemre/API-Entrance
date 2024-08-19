using System.ComponentModel.DataAnnotations;

namespace API_Entrance.Core.DTO.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [MaxLength(30, ErrorMessage = "30 karakter sınırını aştınız!")]
        public string Name { get; set; }
    }
}
