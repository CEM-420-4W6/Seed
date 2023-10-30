using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedmanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatHouse",
                columns: table => new
                {
                    CatsId = table.Column<int>(type: "int", nullable: false),
                    HousesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatHouse", x => new { x.CatsId, x.HousesId });
                    table.ForeignKey(
                        name: "FK_CatHouse_Cats_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatHouse_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74721a19-251a-460a-bd0b-af41c81ef0b9", "AQAAAAIAAYagAAAAEDgamtE47afHTyUnbyOhBW917kXrWuZQeCVRHCgI2g4SJdHHihbkkhXVpOTn3gRPXQ==", "9383bab7-0b73-405b-bcd6-83efda0b7497" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address" },
                values: new object[] { 1, "123 Whatever st." });

            migrationBuilder.InsertData(
                table: "CatHouse",
                columns: new[] { "CatsId", "HousesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatHouse_HousesId",
                table: "CatHouse",
                column: "HousesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatHouse");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67814ccc-3259-4e9e-bebc-5406181b7296", "AQAAAAIAAYagAAAAEO4ibJlZvuiMh55ty4neEsW/i4YZYOQ8c/qxxrML5iQTpFlEXwIfsr3ShbrkHeqdUg==", "cf8cf29a-e85b-44fc-84a6-393357be34d1" });
        }
    }
}
