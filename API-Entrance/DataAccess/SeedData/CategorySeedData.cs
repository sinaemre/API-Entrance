using API_Entrance.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Entrance.DataAccess.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                    new Category { Id = 1, Name = "Kişisel" },
                    new Category { Id = 2, Name = "İş" },
                    new Category { Id = 3, Name = "Eğitim" }
                );
        }
    }
}
