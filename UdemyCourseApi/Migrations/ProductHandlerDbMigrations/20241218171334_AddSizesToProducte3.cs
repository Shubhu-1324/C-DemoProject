using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    /// <inheritdoc />
    public partial class AddSizesToProducte3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c48b3eb-42f5-4c22-a4d5-3e13381cc082"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2de839d-13bb-484b-9bd1-1517ffb4843e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddb2e705-282d-44f4-992c-382380e190ad"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AvailableSizesSerialized",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("6c48b3eb-42f5-4c22-a4d5-3e13381cc082"), "Men", null },
                    { new Guid("b2de839d-13bb-484b-9bd1-1517ffb4843e"), "Women", null },
                    { new Guid("ddb2e705-282d-44f4-992c-382380e190ad"), "Child", null }
                });
        }
    }
}
