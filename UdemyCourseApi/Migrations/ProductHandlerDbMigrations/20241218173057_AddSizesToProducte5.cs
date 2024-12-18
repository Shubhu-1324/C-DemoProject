using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("14d020b4-5917-4723-a152-772c8177eef1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3afc547d-a73b-4063-ac0a-becb42af6acb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a12d32ae-2b54-4ece-a14b-47200332fc89"));

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductSizes",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSizes", x => new { x.ProductId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ProductProductSizes_ProductSizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSizes_SizesId",
                table: "ProductProductSizes",
                column: "SizesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSizes");

            migrationBuilder.DropTable(
                name: "ProductSizes");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("14d020b4-5917-4723-a152-772c8177eef1"), "Men", null },
                    { new Guid("3afc547d-a73b-4063-ac0a-becb42af6acb"), "Women", null },
                    { new Guid("a12d32ae-2b54-4ece-a14b-47200332fc89"), "Child", null }
                });
        }
    }
}
