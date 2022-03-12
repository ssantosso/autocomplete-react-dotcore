using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autocomplete.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", nullable: true),
                    country = table.Column<string>(type: "varchar(200)", nullable: true),
                    subcountry = table.Column<string>(type: "varchar(200)", nullable: true),
                    geonameid = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
