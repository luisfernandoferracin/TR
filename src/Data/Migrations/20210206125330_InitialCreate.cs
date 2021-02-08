using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalCases",
                columns: table => new
                {
                    CaseNumber = table.Column<string>(type: "varchar(24)", nullable: false),
                    CourtName = table.Column<string>(type: "varchar(50)", nullable: false),
                    NameResponsible = table.Column<string>(type: "varchar(50)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCases", x => x.CaseNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalCases");
        }
    }
}
