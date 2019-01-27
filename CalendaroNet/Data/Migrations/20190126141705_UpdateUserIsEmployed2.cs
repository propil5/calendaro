using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendaroNet.Data.Migrations
{
    public partial class UpdateUserIsEmployed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isEmployed",
                table: "AspNetUsers",
                newName: "IsEmployed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEmployed",
                table: "AspNetUsers",
                newName: "isEmployed");
        }
    }
}
