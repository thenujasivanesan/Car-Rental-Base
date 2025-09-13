using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfileAndCarDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NICNumber",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                columns: new[] { "Brand", "CarName", "Seats" },
                values: new object[] { "Toyota", "Camry", 5 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 2,
                columns: new[] { "Brand", "CarName", "Seats" },
                values: new object[] { "Honda", "Civic", 5 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 3,
                columns: new[] { "Brand", "CarName", "Seats" },
                values: new object[] { "BMW", "X5", 7 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FullName", "NICNumber", "PhoneNumber" },
                values: new object[] { "123 Admin Street, Admin City", "admin@carrentalsystem.com", "System Administrator", "ADMIN123456789", "+1234567890" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NICNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 1,
                column: "CarName",
                value: "Toyota Camry");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 2,
                column: "CarName",
                value: "Honda Civic");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarID",
                keyValue: 3,
                column: "CarName",
                value: "BMW X5");
        }
    }
}
