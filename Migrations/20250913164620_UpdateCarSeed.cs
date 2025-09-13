using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://global.toyota/pages/models/images/20191018/kv/camry_w1920_01.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://via.placeholder.com/300x200?text=Toyota+Camry");
        }
    }
}
