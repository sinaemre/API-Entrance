using API_Entrance.Core.Entities.Abstract;

namespace API_Entrance.Core.DTO.CategoryDTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
