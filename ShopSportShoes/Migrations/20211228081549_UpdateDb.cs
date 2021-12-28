using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSportShoes.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Image",
                newName: "ImageName");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageSource",
                table: "Image",
                type: "RAW(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Image",
                newName: "Path");
        }
    }
}
