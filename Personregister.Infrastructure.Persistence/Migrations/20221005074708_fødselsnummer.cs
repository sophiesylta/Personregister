using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personregister.Infrastructure.Persistence.Migrations
{
    public partial class fødselsnummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personer_Personnummer",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "Personnummer",
                table: "Personer");

            migrationBuilder.AlterColumn<string>(
                name: "Kallenavn",
                table: "Personer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "_Fødselsnummer",
                table: "Personer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Personer__Fødselsnummer",
                table: "Personer",
                column: "_Fødselsnummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personer_Kallenavn",
                table: "Personer",
                column: "Kallenavn",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personer__Fødselsnummer",
                table: "Personer");

            migrationBuilder.DropIndex(
                name: "IX_Personer_Kallenavn",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "_Fødselsnummer",
                table: "Personer");

            migrationBuilder.AlterColumn<string>(
                name: "Kallenavn",
                table: "Personer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "Personnummer",
                table: "Personer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Personer_Personnummer",
                table: "Personer",
                column: "Personnummer",
                unique: true);
        }
    }
}
