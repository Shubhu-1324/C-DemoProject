using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddCityToProducte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

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
    }
}
