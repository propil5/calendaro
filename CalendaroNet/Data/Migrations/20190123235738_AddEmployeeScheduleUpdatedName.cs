using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class AddEmployeeScheduleUpdatedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SureName",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SureName",
                table: "Employees");
        }
    }
}
