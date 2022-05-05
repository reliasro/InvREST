using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soinsoft.Inventory.Infra.Persistence.Migrations
{
    public partial class Removedtransfinalexistence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalExistence",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalExistence",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
