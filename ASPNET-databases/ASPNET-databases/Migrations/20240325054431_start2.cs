using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNET_databases.Migrations
{
    /// <inheritdoc />
    public partial class start2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 1,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 2,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 4,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 5,
                column: "InStock",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 1,
                column: "InStock",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 2,
                column: "InStock",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 4,
                column: "InStock",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 5,
                column: "InStock",
                value: false);
        }
    }
}
