using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPNET_databases.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Artilery" },
                    { 2, "Light tank" },
                    { 3, "Medium tank" },
                    { 4, "Heavy tank" },
                    { 5, "Anti Air" },
                    { 6, "SAU" },
                    { 7, "Armored Vehicle" }
                });

            migrationBuilder.InsertData(
                table: "Tanks",
                columns: new[] { "Id", "ClassId", "Description", "ImageUrl", "InStock", "Mileage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 4, null, "https://static.wikia.nocookie.net/warrior/images/9/99/%D0%9C%D0%B0%D1%83%D1%81.jpg/revision/latest?cb=20161026163157&path-prefix=ru", false, 300000m, "Mous", 62000000m },
                    { 2, 6, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIFoboNP10mBMf2M8iP5Oobk33BPO-D8Xnbg&usqp=CAU", false, 50000m, "FV 4005", 5500000m },
                    { 3, 4, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd4pM8QXXE0pDnHCzYlFzo00Do0OM-Ji1QTw&usqp=CAU", false, 1235600m, "Tiger 2 H", 3400000m },
                    { 4, 3, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIVy6NiR6fNrBU4hUpEAJ8Rz4M8rKz4B1eVA&usqp=CAU", false, 230435m, "M4A3E2", 1800400m },
                    { 5, 6, null, "https://tankhistoria.com/wp-content/uploads/2022/05/Alkett-Factory-March-9th-1942.jpg", false, 300000m, "Sturer Emil", 650000m },
                    { 6, 1, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHWf6GAXSoEUnSGyN5yErH3cdzeULJv5CIgA&usqp=CAU", false, 350m, "Heavy Gustav", 5000000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ClassId",
                table: "Tanks",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
