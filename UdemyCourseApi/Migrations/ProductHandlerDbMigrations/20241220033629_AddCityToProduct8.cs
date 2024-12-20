using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddCityToProduct8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2b14e240-a021-4e36-95e5-7d7a7c467d8b"), "Men", null },
                    { new Guid("adc82860-3278-4913-a425-fcd210be54e6"), "Child", null },
                    { new Guid("fe4efccf-5dea-4399-90fd-c8af2c914f2e"), "Women", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b14e240-a021-4e36-95e5-7d7a7c467d8b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("adc82860-3278-4913-a425-fcd210be54e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe4efccf-5dea-4399-90fd-c8af2c914f2e"));

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
    }
}
