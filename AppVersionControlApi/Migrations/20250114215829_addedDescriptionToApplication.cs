using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVersionControlApi.Migrations
{
    /// <inheritdoc />
    public partial class addedDescriptionToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14ca8707-1d00-4b68-964f-fe94e333f43f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d734d8c5-be11-432e-ab1f-0f45f437892b");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bb090ad3-355c-4afb-97c4-322468bca672", null, "admin", "ADMIN" },
                    { "d1db793a-cadf-445a-a84f-5a216ef60f7c", null, "user", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb090ad3-355c-4afb-97c4-322468bca672");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1db793a-cadf-445a-a84f-5a216ef60f7c");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14ca8707-1d00-4b68-964f-fe94e333f43f", null, "admin", "ADMIN" },
                    { "d734d8c5-be11-432e-ab1f-0f45f437892b", null, "user", "User" }
                });
        }
    }
}
