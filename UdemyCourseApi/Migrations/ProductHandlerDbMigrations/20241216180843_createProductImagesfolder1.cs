using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class createProductImagesfolder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77c3096b-eda4-4955-b84b-258e64a02c81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a02ad5ee-9d90-4f3c-987c-75cc24a5a3a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3c2afc9-57ac-40f6-9943-9d797a0240c9"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("119a5649-53eb-453c-8efd-a29617b74f98"), "Men", null },
                    { new Guid("6fd5d2ff-100e-4db5-862b-fcbdfe9612b3"), "Women", null },
                    { new Guid("861ef157-a112-47a1-b5b7-61a0f4615fa9"), "Child", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("119a5649-53eb-453c-8efd-a29617b74f98"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6fd5d2ff-100e-4db5-862b-fcbdfe9612b3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("861ef157-a112-47a1-b5b7-61a0f4615fa9"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("77c3096b-eda4-4955-b84b-258e64a02c81"), "Child", null },
                    { new Guid("a02ad5ee-9d90-4f3c-987c-75cc24a5a3a7"), "Men", null },
                    { new Guid("f3c2afc9-57ac-40f6-9943-9d797a0240c9"), "Women", null }
                });
        }
    }
}
