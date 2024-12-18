using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class createProductImagesfolder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("4297f6b2-7118-4814-9447-747b58523ea8"), "Women", null },
                    { new Guid("c3544214-2c1e-4d64-90dd-aad26b9672b9"), "Men", null },
                    { new Guid("dacc221b-ea6a-4123-b782-b8bf3f192efd"), "Child", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4297f6b2-7118-4814-9447-747b58523ea8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3544214-2c1e-4d64-90dd-aad26b9672b9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dacc221b-ea6a-4123-b782-b8bf3f192efd"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

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
    }
}
