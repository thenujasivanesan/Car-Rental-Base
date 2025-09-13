using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class CarData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/930x620/Toyota/Camry/11344/1733916451269/front-left-side-47.jpg?imwidth=890&impolicy=resize");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://media.ed.edmunds-media.com/honda/civic/2026/oem/2026_honda_civic_sedan_si_fq_oem_1_815.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.topgear.com/sites/default/files/2024/05/P90489757_highRes_the-new-bmw-x5-xdriv_0.jpg?w=1784&h=1004");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://global.toyota/pages/models/images/20191018/kv/camry_w1920_01.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://via.placeholder.com/300x200?text=Honda+Civic");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://via.placeholder.com/300x200?text=BMW+X5");
        }
    }
}
