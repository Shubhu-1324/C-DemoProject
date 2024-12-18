using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.NzWalksAuthDb
{
    /// <inheritdoc />
    public partial class newRolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7d1b5a1-e249-4f88-830d-b08b8e13b0b9", "a7d1b5a1-e249-4f88-830d-b08b8e13b0b9", "Admin", "ADMIN" },
                    { "b0c7ccad-87c2-4874-8e3b-e7e2a9234056", "b0c7ccad-87c2-4874-8e3b-e7e2a9234056", "Vendor", "VENDOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d1b5a1-e249-4f88-830d-b08b8e13b0b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c7ccad-87c2-4874-8e3b-e7e2a9234056");
        }
    }
}
