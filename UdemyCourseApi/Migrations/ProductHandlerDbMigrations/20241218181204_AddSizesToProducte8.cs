using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e8fec38-2091-4b2a-bcbf-25719f9ae89e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("905f66dd-df33-4508-85f2-14f58a677113"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfff0c5b-ed6a-4ad3-a937-1394eb004948"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("55f0246b-22f8-4dca-8c22-c4843b089523"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("945a7842-6949-46c5-9f91-61c9d944413d"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("be99fa21-8139-4393-9b28-6ebe394eb4b3"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("e626faa2-14b3-45ef-a996-6b48e2039f3b"));

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentalDuration",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalDuration",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("7e8fec38-2091-4b2a-bcbf-25719f9ae89e"), "Men", null },
                    { new Guid("905f66dd-df33-4508-85f2-14f58a677113"), "Child", null },
                    { new Guid("bfff0c5b-ed6a-4ad3-a937-1394eb004948"), "Women", null }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("55f0246b-22f8-4dca-8c22-c4843b089523"), "Large" },
                    { new Guid("945a7842-6949-46c5-9f91-61c9d944413d"), "Small" },
                    { new Guid("be99fa21-8139-4393-9b28-6ebe394eb4b3"), "Medium" },
                    { new Guid("e626faa2-14b3-45ef-a996-6b48e2039f3b"), "X-Large" }
                });
        }
    }
}
