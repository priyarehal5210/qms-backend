using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystemBackend.Migrations
{
    public partial class removingcold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "assignedTasks");

            migrationBuilder.DropColumn(
                name: "success",
                table: "assignedTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "assignedTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "success",
                table: "assignedTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
