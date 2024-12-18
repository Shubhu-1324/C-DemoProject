using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e51af5d-d5ec-47fb-9233-7c941048cf27"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b586faae-505b-4c87-a6a0-9ef89205d2d7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6dbc7ed-99c1-4fee-8418-a48b199d4c67"));

            migrationBuilder.DropColumn(
                name: "AvailableSizes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableSizesSerialized",
                table: "Products");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AvailableSizes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableSizesSerialized",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("2e51af5d-d5ec-47fb-9233-7c941048cf27"), "Women", null },
                    { new Guid("b586faae-505b-4c87-a6a0-9ef89205d2d7"), "Men", null },
                    { new Guid("c6dbc7ed-99c1-4fee-8418-a48b199d4c67"), "Child", null }
                });
        }
    }
}
