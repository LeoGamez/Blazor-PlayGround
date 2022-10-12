using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.Server.Playground.Data.Migrations
{
    public partial class Seedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "411b5bd2-590d-4f6b-a3be-66f1a21abca2", "e44b793b-ab81-44f1-b0c7-d2fbf79f8b5a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "469e945a-fa35-4708-96ee-a4f86a600c27", "6340ac8f-7022-4ae6-8207-ba9809e6a22a", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "411b5bd2-590d-4f6b-a3be-66f1a21abca2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "469e945a-fa35-4708-96ee-a4f86a600c27");
        }
    }
}
