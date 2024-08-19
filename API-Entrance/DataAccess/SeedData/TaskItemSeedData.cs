using API_Entrance.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Entrance.DataAccess.SeedData
{
    public class TaskItemSeedData : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasData
                (
                    new TaskItem
                    {
                        Id = 1,
                        Title = "Kitap Oku",
                        Description = "Haftaya kadar 1 adet kitap bitir.",
                        IsCompleted = false,
                        Deadline = DateTime.Now.AddDays(7).Date,
                        CategoryId = 1
                    },
                    new TaskItem
                    {
                        Id = 2,
                        Title = "Yazılım Projesine Bak",
                        Description = "Verilen taskları tamamla!",
                        IsCompleted = false,
                        Deadline = DateTime.Now.AddDays(-2).Date,
                        CategoryId = 2
                    },
                    new TaskItem
                    {
                        Id = 3,
                        Title = "Ders Çalış",
                        Description = "Yeni teknolojiler hakkında araştırma yap!",
                        IsCompleted = true,
                        Deadline = DateTime.Now.AddDays(-3).Date,
                        CategoryId = 3
                    }
                );
        }
    }
}
