using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSportShoes.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageSoure",
                table: "Image",
                type: "blob",
                maxLength: 5000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSoure",
                table: "Image");
        }
    }
}
