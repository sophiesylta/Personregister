using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personregister.WebAPI.Migrations
{
    public partial class kallenavn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kallenavn",
                table: "Personer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kallenavn",
                table: "Personer");
        }
    }
}
