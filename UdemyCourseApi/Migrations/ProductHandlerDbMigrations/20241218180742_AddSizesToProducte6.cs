using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6dc45eed-2d08-470f-9489-52b33ea86b14"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc14ba8f-c4d7-452f-ad32-bc396ea0d346"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea0eedd0-72ba-4b8b-a3ba-c11dcddd67f8"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("5842ef55-f6bf-4bbe-9987-c9ff15607877"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("833ee945-e6e0-4948-a179-6906ec9f7eda"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("e95509a3-7ea7-4bbc-9d44-9227c6fadafd"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("efbafc15-9242-4630-8b7e-e10a8c3b8028"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabric",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecurityDeposit",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fabric",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecurityDeposit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("6dc45eed-2d08-470f-9489-52b33ea86b14"), "Child", null },
                    { new Guid("cc14ba8f-c4d7-452f-ad32-bc396ea0d346"), "Women", null },
                    { new Guid("ea0eedd0-72ba-4b8b-a3ba-c11dcddd67f8"), "Men", null }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("5842ef55-f6bf-4bbe-9987-c9ff15607877"), "X-Large" },
                    { new Guid("833ee945-e6e0-4948-a179-6906ec9f7eda"), "Small" },
                    { new Guid("e95509a3-7ea7-4bbc-9d44-9227c6fadafd"), "Large" },
                    { new Guid("efbafc15-9242-4630-8b7e-e10a8c3b8028"), "Medium" }
                });
        }
    }
}
