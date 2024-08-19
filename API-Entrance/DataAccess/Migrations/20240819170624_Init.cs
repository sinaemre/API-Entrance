using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Entrance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Deadline = table.Column<DateTime>(type: "date", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(674), null, "Kişisel", 1, null },
                    { 2, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(759), null, "İş", 1, null },
                    { 3, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(760), null, "Eğitim", 1, null }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Deadline", "DeletedDate", "Description", "IsCompleted", "Status", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(1270), new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), null, "Haftaya kadar 1 adet kitap bitir.", false, 1, "Kitap Oku", null },
                    { 2, 2, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(1339), new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), null, "Verilen taskları tamamla!", false, 1, "Yazılım Projesine Bak", null },
                    { 3, 3, new DateTime(2024, 8, 19, 20, 6, 23, 831, DateTimeKind.Local).AddTicks(1343), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Local), null, "Yeni teknolojiler hakkında araştırma yap!", true, 1, "Ders Çalış", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryId",
                table: "TaskItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
