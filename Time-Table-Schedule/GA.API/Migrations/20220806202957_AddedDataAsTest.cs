using Microsoft.EntityFrameworkCore.Migrations;

namespace GA.API.Migrations
{
    public partial class AddedDataAsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datum",
                columns: table => new
                {
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datum");
        }
    }
}
