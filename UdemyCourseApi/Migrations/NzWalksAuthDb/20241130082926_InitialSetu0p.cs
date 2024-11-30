using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.NzWalksAuthDb
{
    /// <inheritdoc />
    public partial class InitialSetu0p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2177ea-369a-4379-bb3e-d53c6d73f2a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b378f33-1900-41c7-a721-ca76ec87e58d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ac1caae-d8f1-4196-975e-6fa5d25b92a7", "5ac1caae-d8f1-4196-975e-6fa5d25b92a7", "Writer", "WRITER" },
                    { "e1d43a91-2c43-4e0b-8430-1b8f3e378401", "e1d43a91-2c43-4e0b-8430-1b8f3e378401", "Reader", "READER" },
                    { "8df90e0d-024f-453b-90e3-226ca20882db", "8df90e0d-024f-453b-90e3-226ca20882db", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac1caae-d8f1-4196-975e-6fa5d25b92a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d43a91-2c43-4e0b-8430-1b8f3e378401");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d2177ea-369a-4379-bb3e-d53c6d73f2a7", "3d2177ea-369a-4379-bb3e-d53c6d73f2a7", "Writer", "WRITER" },
                    { "6b378f33-1900-41c7-a721-ca76ec87e58d", "6b378f33-1900-41c7-a721-ca76ec87e58d", "Reader", "READER" }
                });
        }
    }
}
