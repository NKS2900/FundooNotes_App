using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepositiory.Migrations
{
    public partial class Fundoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundooTable",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundooTable", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "NoteTable",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Pin = table.Column<bool>(nullable: false),
                    Reminder = table.Column<string>(nullable: true),
                    Collaborator = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Archive = table.Column<bool>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTable", x => x.NoteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundooTable");

            migrationBuilder.DropTable(
                name: "NoteTable");
        }
    }
}
