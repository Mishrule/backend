using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.API.Migrations
{
    public partial class RenameClassesToClasss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Datas");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Datas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Datas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Datas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
