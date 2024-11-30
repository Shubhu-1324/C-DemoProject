﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCourseApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetu0p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "regions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"),
                column: "City",
                value: null);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                column: "City",
                value: null);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                column: "City",
                value: null);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                column: "City",
                value: null);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                column: "City",
                value: null);

            migrationBuilder.UpdateData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                column: "City",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "regions");
        }
    }
}
