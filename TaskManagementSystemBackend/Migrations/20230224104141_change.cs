using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystemBackend.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "assignedTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "assignedTasks");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
