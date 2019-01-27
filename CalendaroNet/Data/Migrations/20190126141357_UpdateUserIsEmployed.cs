using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class UpdateUserIsEmployed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEmployed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEmployed",
                table: "AspNetUsers");
        }
    }
}
