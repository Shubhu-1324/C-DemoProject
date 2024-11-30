using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCourseApi.Migrations.NzWalksAuthDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d2177ea-369a-4379-bb3e-d53c6d73f2a8", "3d2177ea-369a-4379-bb3e-d53c6d73f2a8", "Admin", "WRITER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2177ea-369a-4379-bb3e-d53c6d73f2a8");
        }
    }
}
