using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personregister.Infrastructure.Persistence.Migrations
{
    public partial class personnummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personer_Personnummer",
                table: "Personer",
                column: "Personnummer",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personer_Personnummer",
                table: "Personer");
        }
    }
}
