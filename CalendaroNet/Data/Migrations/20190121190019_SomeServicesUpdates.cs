using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class SomeServicesUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeRequired",
                table: "Services");

            migrationBuilder.AddColumn<double>(
                name: "PriceInPln",
                table: "Services",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TimeRequiredInMinutes",
                table: "Services",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInPln",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TimeRequiredInMinutes",
                table: "Services");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeRequired",
                table: "Services",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
