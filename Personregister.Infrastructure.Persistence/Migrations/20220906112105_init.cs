using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personregister.Infrastructure.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etternavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnummer = table.Column<long>(type: "bigint", nullable: false),
                    Kallenavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Dødsfall",
                columns: table => new
                {
                    DødsfallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    dødsårsak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dødsTid = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dødsfall", x => x.DødsfallId);
                    table.ForeignKey(
                        name: "FK_Dødsfall_Personer_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personer",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fødsler",
                columns: table => new
                {
                    FødselId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    morPersonId = table.Column<int>(type: "int", nullable: true),
                    farPersonId = table.Column<int>(type: "int", nullable: true),
                    barnPersonId = table.Column<int>(type: "int", nullable: true),
                    fødselTid = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fødsler", x => x.FødselId);
                    table.ForeignKey(
                        name: "FK_Fødsler_Personer_barnPersonId",
                        column: x => x.barnPersonId,
                        principalTable: "Personer",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Fødsler_Personer_farPersonId",
                        column: x => x.farPersonId,
                        principalTable: "Personer",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Fødsler_Personer_morPersonId",
                        column: x => x.morPersonId,
                        principalTable: "Personer",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dødsfall_PersonId",
                table: "Dødsfall",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fødsler_barnPersonId",
                table: "Fødsler",
                column: "barnPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fødsler_farPersonId",
                table: "Fødsler",
                column: "farPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fødsler_morPersonId",
                table: "Fødsler",
                column: "morPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dødsfall");

            migrationBuilder.DropTable(
                name: "Fødsler");

            migrationBuilder.DropTable(
                name: "Personer");
        }
    }
}
