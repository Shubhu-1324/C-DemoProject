using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3a264abe-d268-470f-a149-342c05518b57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d814cf8c-3db2-49c1-b61c-581514cd474b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc71b2d3-983b-47b6-8d02-187e2ad3a70b"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("2973d482-37f5-4192-afc6-1579b4fbf6f3"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("56397ceb-72de-4b47-a6ac-879ffe9edbaf"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("61cef7d6-6e98-4abe-81f1-1dde2fdf9e07"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("fe0a43d1-d572-4795-ad3c-6c16230186a3"));

            migrationBuilder.AlterColumn<int>(
                name: "RentalDuration",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("00278036-36b6-413a-846d-a94ef8524230"), "Women", null },
                    { new Guid("7cdeee6d-abcc-4e01-a6dc-4a462f91fc99"), "Men", null },
                    { new Guid("a0db5ff9-4c28-4d0f-afb7-848edb51ab5d"), "Child", null }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("91766ec7-1efc-44ff-bd36-bffa18e5ef20"), "Small" },
                    { new Guid("926f53fe-2591-4872-be84-047c0f6a8d2b"), "X-Large" },
                    { new Guid("acf1dc39-dc67-4b6d-bdd6-25dd9fcd90d6"), "Medium" },
                    { new Guid("c001358d-d66e-4563-8f48-1d8bda05e17c"), "Large" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("91766ec7-1efc-44ff-bd36-bffa18e5ef20"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("926f53fe-2591-4872-be84-047c0f6a8d2b"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("acf1dc39-dc67-4b6d-bdd6-25dd9fcd90d6"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c001358d-d66e-4563-8f48-1d8bda05e17c"));

            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "RentalDuration",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("3a264abe-d268-470f-a149-342c05518b57"), "Women", null },
                    { new Guid("d814cf8c-3db2-49c1-b61c-581514cd474b"), "Men", null },
                    { new Guid("dc71b2d3-983b-47b6-8d02-187e2ad3a70b"), "Child", null }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("2973d482-37f5-4192-afc6-1579b4fbf6f3"), "X-Large" },
                    { new Guid("56397ceb-72de-4b47-a6ac-879ffe9edbaf"), "Small" },
                    { new Guid("61cef7d6-6e98-4abe-81f1-1dde2fdf9e07"), "Large" },
                    { new Guid("fe0a43d1-d572-4795-ad3c-6c16230186a3"), "Medium" }
                });
        }
    }
}
