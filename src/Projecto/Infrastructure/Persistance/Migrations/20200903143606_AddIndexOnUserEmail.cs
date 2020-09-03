using Microsoft.EntityFrameworkCore.Migrations;

namespace Projecto.Infrastructure.Persistance.Migrations
{
    public partial class AddIndexOnUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_PrimaryEmail",
                table: "Users",
                column: "PrimaryEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PrimaryEmail",
                table: "Users");
        }
    }
}
