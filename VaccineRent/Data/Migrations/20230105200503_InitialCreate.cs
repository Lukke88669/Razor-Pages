using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccineRent.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveModerna = table.Column<bool>(type: "bit", nullable: false),
                    HaveAZ = table.Column<bool>(type: "bit", nullable: false),
                    HaveBNT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hospital_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Rent");
        }
    }
}
