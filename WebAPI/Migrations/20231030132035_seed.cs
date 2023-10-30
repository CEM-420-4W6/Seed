using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "67814ccc-3259-4e9e-bebc-5406181b7296", "jim@test.com", false, false, null, "JIM@TEST.COM", "JIM@TEST.COM", "AQAAAAIAAYagAAAAEO4ibJlZvuiMh55ty4neEsW/i4YZYOQ8c/qxxrML5iQTpFlEXwIfsr3ShbrkHeqdUg==", null, false, "cf8cf29a-e85b-44fc-84a6-393357be34d1", false, "jim@test.com" });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "DemoUserId", "Name" },
                values: new object[,]
                {
                    { 1, "11111111-1111-1111-1111-111111111111", "Dali" },
                    { 2, "11111111-1111-1111-1111-111111111111", "Linda" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");
        }
    }
}
