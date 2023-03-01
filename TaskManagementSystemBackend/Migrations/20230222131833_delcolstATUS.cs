using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystemBackend.Migrations
{
    public partial class delcolstATUS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
