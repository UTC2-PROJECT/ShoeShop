using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSportShoes.Migrations
{
    public partial class UpdateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ThumbnailLink",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Image",
                type: "NCLOB",
                maxLength: 2147483647,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Image",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailLink",
                table: "Image",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
