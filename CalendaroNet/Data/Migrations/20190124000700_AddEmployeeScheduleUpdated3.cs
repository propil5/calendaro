using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class AddEmployeeScheduleUpdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SureName",
                table: "Employees",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Employees",
                newName: "SureName");
        }
    }
}
