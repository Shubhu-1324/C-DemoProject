using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddCityToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("69097f64-e2ba-46be-a7d9-ae21a26f5ae6"), "Men", null },
                    { new Guid("ab23dc19-30be-487f-92d5-0dbc1c915208"), "Child", null },
                    { new Guid("d84d2f45-18e4-4bad-af2d-265e1eff179a"), "Women", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69097f64-e2ba-46be-a7d9-ae21a26f5ae6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ab23dc19-30be-487f-92d5-0dbc1c915208"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d84d2f45-18e4-4bad-af2d-265e1eff179a"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

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
    }
}
