using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class AddedIsActiveToLeaveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LeaveTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LeaveTypes");
        }
    }
}
