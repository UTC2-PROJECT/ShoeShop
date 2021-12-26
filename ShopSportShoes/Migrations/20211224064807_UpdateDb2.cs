using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSportShoes.Migrations
{
    public partial class UpdateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoeSize_Shoes_ShoeId",
                table: "ShoeSize");

            migrationBuilder.DropTable(
                name: "ImageSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeSize",
                table: "ShoeSize");

            migrationBuilder.DropIndex(
                name: "IX_ShoeSize_ShoeId",
                table: "ShoeSize");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "ShoeSize");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoeSize",
                newName: "SizeId");

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "ShoeSize",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "ShoeSize",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeSize",
                table: "ShoeSize",
                columns: new[] { "ShoeId", "SizeId" });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Path = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ShoeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SizeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSize_SizeId",
                table: "ShoeSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ShoeId",
                table: "Image",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeSize_Shoes_ShoeId",
                table: "ShoeSize",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeSize_Size_SizeId",
                table: "ShoeSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoeSize_Shoes_ShoeId",
                table: "ShoeSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeSize_Size_SizeId",
                table: "ShoeSize");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeSize",
                table: "ShoeSize");

            migrationBuilder.DropIndex(
                name: "IX_ShoeSize_SizeId",
                table: "ShoeSize");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ShoeSize",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "ShoeSize",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShoeSize",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "ShoeSize",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeSize",
                table: "ShoeSize",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ImageSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Path = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ShoeId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageSource_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSize_ShoeId",
                table: "ShoeSize",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSource_ShoeId",
                table: "ImageSource",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeSize_Shoes_ShoeId",
                table: "ShoeSize",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
