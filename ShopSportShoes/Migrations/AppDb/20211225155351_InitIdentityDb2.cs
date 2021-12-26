using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSportShoes.Migrations.AppDb
{
    public partial class InitIdentityDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e09d979-8871-48e1-bb23-a58829cf2849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6678261f-54bc-4cdc-afe8-60652ddcea7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d6da58e-c68f-4799-8102-158516e5e984", "203cd139-1f06-4c4e-b1a5-f21519a5c7fb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e3a22dd-82c9-424c-9bf5-ca8f53b7b7df", "213e5b29-4019-445a-bc61-764adef2c293", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3a22dd-82c9-424c-9bf5-ca8f53b7b7df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d6da58e-c68f-4799-8102-158516e5e984");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6678261f-54bc-4cdc-afe8-60652ddcea7f", "5034c4b7-f6a9-41ec-8586-a77ac331906d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e09d979-8871-48e1-bb23-a58829cf2849", "893c43c7-eedb-4f39-b7b8-0e9fc434f7b9", "Admin", "ADMIN" });
        }
    }
}
