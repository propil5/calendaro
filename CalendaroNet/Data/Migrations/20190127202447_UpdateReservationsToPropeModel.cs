using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class UpdateReservationsToPropeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServiceReservations",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "ServiceReservations",
                newName: "ReservationTime");

            migrationBuilder.AddColumn<string>(
                name: "AbsenceReason",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ServiceReservations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EstimatedTime",
                table: "ServiceReservations",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_EmployeeId",
                table: "ServiceReservations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_ServiceId",
                table: "ServiceReservations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId",
                table: "ServiceReservations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId",
                table: "ServiceReservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId",
                table: "ServiceReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_EmployeeId",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_ServiceId",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "AbsenceReason",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "ServiceReservations");

            migrationBuilder.RenameColumn(
                name: "ReservationTime",
                table: "ServiceReservations",
                newName: "ReservationDate");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ServiceReservations",
                newName: "UserId");
        }
    }
}
