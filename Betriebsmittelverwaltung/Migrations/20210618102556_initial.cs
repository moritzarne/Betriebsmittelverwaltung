using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Betriebsmittelverwaltung.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestandsverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    Kaufdatum = table.Column<DateTime>(nullable: false),
                    Wartungsintervall = table.Column<TimeSpan>(nullable: false),
                    Verfübar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestandsverwaltung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nutzerverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolle = table.Column<int>(nullable: false),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutzerverwaltung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Baustellenverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Beschreibung = table.Column<string>(nullable: true),
                    BauleiterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baustellenverwaltung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Baustellenverwaltung_Nutzerverwaltung_BauleiterID",
                        column: x => x.BauleiterID,
                        principalTable: "Nutzerverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projektverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    Ausleihdatum = table.Column<DateTime>(nullable: false),
                    Rückgabe = table.Column<string>(nullable: true),
                    BaustellenverwaltungID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projektverwaltung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projektverwaltung_Baustellenverwaltung_BaustellenverwaltungID",
                        column: x => x.BaustellenverwaltungID,
                        principalTable: "Baustellenverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auftragsverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    ProjektIDID = table.Column<int>(nullable: true),
                    BauleiterID = table.Column<int>(nullable: true),
                    Verfügbar = table.Column<bool>(nullable: false),
                    BestandsverwaltungID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auftragsverwaltung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Auftragsverwaltung_Nutzerverwaltung_BauleiterID",
                        column: x => x.BauleiterID,
                        principalTable: "Nutzerverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auftragsverwaltung_Bestandsverwaltung_BestandsverwaltungID",
                        column: x => x.BestandsverwaltungID,
                        principalTable: "Bestandsverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auftragsverwaltung_Projektverwaltung_ProjektIDID",
                        column: x => x.ProjektIDID,
                        principalTable: "Projektverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Retourenverwaltung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    Kaufdatum = table.Column<DateTime>(nullable: false),
                    Wartungsintverall = table.Column<TimeSpan>(nullable: false),
                    Verfügbar = table.Column<bool>(nullable: false),
                    BestandsverwaltungID = table.Column<int>(nullable: true),
                    ProjektverwaltungID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retourenverwaltung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Retourenverwaltung_Bestandsverwaltung_BestandsverwaltungID",
                        column: x => x.BestandsverwaltungID,
                        principalTable: "Bestandsverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Retourenverwaltung_Projektverwaltung_ProjektverwaltungID",
                        column: x => x.ProjektverwaltungID,
                        principalTable: "Projektverwaltung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auftragsverwaltung_BauleiterID",
                table: "Auftragsverwaltung",
                column: "BauleiterID");

            migrationBuilder.CreateIndex(
                name: "IX_Auftragsverwaltung_BestandsverwaltungID",
                table: "Auftragsverwaltung",
                column: "BestandsverwaltungID");

            migrationBuilder.CreateIndex(
                name: "IX_Auftragsverwaltung_ProjektIDID",
                table: "Auftragsverwaltung",
                column: "ProjektIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Baustellenverwaltung_BauleiterID",
                table: "Baustellenverwaltung",
                column: "BauleiterID");

            migrationBuilder.CreateIndex(
                name: "IX_Projektverwaltung_BaustellenverwaltungID",
                table: "Projektverwaltung",
                column: "BaustellenverwaltungID");

            migrationBuilder.CreateIndex(
                name: "IX_Retourenverwaltung_BestandsverwaltungID",
                table: "Retourenverwaltung",
                column: "BestandsverwaltungID");

            migrationBuilder.CreateIndex(
                name: "IX_Retourenverwaltung_ProjektverwaltungID",
                table: "Retourenverwaltung",
                column: "ProjektverwaltungID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auftragsverwaltung");

            migrationBuilder.DropTable(
                name: "Retourenverwaltung");

            migrationBuilder.DropTable(
                name: "Bestandsverwaltung");

            migrationBuilder.DropTable(
                name: "Projektverwaltung");

            migrationBuilder.DropTable(
                name: "Baustellenverwaltung");

            migrationBuilder.DropTable(
                name: "Nutzerverwaltung");
        }
    }
}
