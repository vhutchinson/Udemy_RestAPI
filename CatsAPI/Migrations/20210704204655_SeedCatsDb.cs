using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAPI.Migrations
{
    public partial class SeedCatsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MyCats",
                columns: new[] { "Id", "Age", "Name", "Type", "Weight" },
                values: new object[] { 1, 7, "Penny", "Torbie", 8.5 });

            migrationBuilder.InsertData(
                table: "MyCats",
                columns: new[] { "Id", "Age", "Name", "Type", "Weight" },
                values: new object[] { 2, 2, "Louise", "Potato", 16.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyCats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyCats",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
