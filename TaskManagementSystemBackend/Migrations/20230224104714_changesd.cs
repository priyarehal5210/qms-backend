using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystemBackend.Migrations
{
    public partial class changesd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                table: "tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
