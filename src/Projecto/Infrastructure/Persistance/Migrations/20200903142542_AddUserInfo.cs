using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Projecto.Infrastructure.Persistance.Migrations
{
    public partial class AddUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    PrimaryEmail = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: false, defaultValue: "Unknown User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
