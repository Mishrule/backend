using Microsoft.EntityFrameworkCore.Migrations;

namespace GA.API.Migrations
{
    public partial class AddedDataAsTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Datum",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datum",
                table: "Datum",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Datum",
                table: "Datum");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Datum");
        }
    }
}
