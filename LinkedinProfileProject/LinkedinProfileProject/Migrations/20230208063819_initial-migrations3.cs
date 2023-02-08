using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkedinProfileProject.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1, "Ankara" },
                    { 2, "İstanbul" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CityId", "DistrictName" },
                values: new object[,]
                {
                    { 1, 1, "Çankaya" },
                    { 2, 1, "Keçiören" },
                    { 3, 2, "Kadıköy" },
                    { 4, 2, "Beyoğlu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
