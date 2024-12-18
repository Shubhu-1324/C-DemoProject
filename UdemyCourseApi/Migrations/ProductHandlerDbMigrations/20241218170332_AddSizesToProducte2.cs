using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("601c5786-0c64-4203-b376-9cae0d07ffb4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("afb4cc50-237e-4524-a9dd-7393dde450e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b19ecd07-a46a-4aab-a2ff-dbb7f4b32093"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("6c48b3eb-42f5-4c22-a4d5-3e13381cc082"), "Men", null },
                    { new Guid("b2de839d-13bb-484b-9bd1-1517ffb4843e"), "Women", null },
                    { new Guid("ddb2e705-282d-44f4-992c-382380e190ad"), "Child", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c48b3eb-42f5-4c22-a4d5-3e13381cc082"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2de839d-13bb-484b-9bd1-1517ffb4843e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddb2e705-282d-44f4-992c-382380e190ad"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("601c5786-0c64-4203-b376-9cae0d07ffb4"), "Men", null },
                    { new Guid("afb4cc50-237e-4524-a9dd-7393dde450e2"), "Child", null },
                    { new Guid("b19ecd07-a46a-4aab-a2ff-dbb7f4b32093"), "Women", null }
                });
        }
    }
}
