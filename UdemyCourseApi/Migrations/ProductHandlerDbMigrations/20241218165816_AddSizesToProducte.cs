using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28e71bd1-2b7c-41eb-ba94-fc80f345280b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ab325d6-5b50-4430-8f20-f77fea7cd022"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d62a561b-11cd-4c36-8cb7-6a05152a4c4e"));

            migrationBuilder.AddColumn<string>(
                name: "AvailableSizes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AvailableSizes",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("28e71bd1-2b7c-41eb-ba94-fc80f345280b"), "Child", null },
                    { new Guid("6ab325d6-5b50-4430-8f20-f77fea7cd022"), "Women", null },
                    { new Guid("d62a561b-11cd-4c36-8cb7-6a05152a4c4e"), "Men", null }
                });
        }
    }
}
