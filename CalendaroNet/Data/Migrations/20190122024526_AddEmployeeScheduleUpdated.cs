using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class AddEmployeeScheduleUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    FinishTime = table.Column<DateTimeOffset>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Present = table.Column<bool>(nullable: true),
                    AbsenceReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSchedule", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesSchedule");
        }
    }
}
