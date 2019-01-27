using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class AddReservationAndUpdateNameOfSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesSchedule",
                table: "EmployeesSchedule");

            migrationBuilder.RenameTable(
                name: "EmployeesSchedule",
                newName: "EmployeesSchedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesSchedules",
                table: "EmployeesSchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ServiceReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ReservationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReservations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSchedules_EmployeeId",
                table: "EmployeesSchedules",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesSchedules_Employees_EmployeeId",
                table: "EmployeesSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesSchedules_Employees_EmployeeId",
                table: "EmployeesSchedules");

            migrationBuilder.DropTable(
                name: "ServiceReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesSchedules",
                table: "EmployeesSchedules");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesSchedules_EmployeeId",
                table: "EmployeesSchedules");

            migrationBuilder.RenameTable(
                name: "EmployeesSchedules",
                newName: "EmployeesSchedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesSchedule",
                table: "EmployeesSchedule",
                column: "Id");
        }
    }
}
