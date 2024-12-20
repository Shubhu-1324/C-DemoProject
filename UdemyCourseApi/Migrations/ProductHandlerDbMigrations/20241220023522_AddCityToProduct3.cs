using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddCityToProduct3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00278036-36b6-413a-846d-a94ef8524230"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cdeee6d-abcc-4e01-a6dc-4a462f91fc99"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a0db5ff9-4c28-4d0f-afb7-848edb51ab5d"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("2dba9d08-4ffb-4a95-9ada-29f146a55e3a"), "Women", null },
                    { new Guid("6081664d-f3f0-4e57-b3ac-796150145330"), "Child", null },
                    { new Guid("b0cfed6e-65f4-43e2-8d21-1cae3b34557d"), "Men", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2dba9d08-4ffb-4a95-9ada-29f146a55e3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6081664d-f3f0-4e57-b3ac-796150145330"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b0cfed6e-65f4-43e2-8d21-1cae3b34557d"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("00278036-36b6-413a-846d-a94ef8524230"), "Women", null },
                    { new Guid("7cdeee6d-abcc-4e01-a6dc-4a462f91fc99"), "Men", null },
                    { new Guid("a0db5ff9-4c28-4d0f-afb7-848edb51ab5d"), "Child", null }
                });
        }
    }
}
