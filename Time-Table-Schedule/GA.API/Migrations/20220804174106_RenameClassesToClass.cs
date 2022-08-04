using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.API.Migrations
{
    public partial class RenameClassesToClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Classes_ClassesId",
                table: "Datas");

            migrationBuilder.DropIndex(
                name: "IX_Datas_ClassesId",
                table: "Datas");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Datas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Datas_ClassId",
                table: "Datas",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Classes_ClassId",
                table: "Datas");

            migrationBuilder.DropIndex(
                name: "IX_Datas_ClassId",
                table: "Datas");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Datas");

            migrationBuilder.CreateIndex(
                name: "IX_Datas_ClassesId",
                table: "Datas",
                column: "ClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Classes_ClassesId",
                table: "Datas",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
