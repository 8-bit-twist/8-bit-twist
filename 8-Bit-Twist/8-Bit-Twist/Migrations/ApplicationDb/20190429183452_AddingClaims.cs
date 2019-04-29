using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations.ApplicationDb
{
    public partial class AddingClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Computer",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Computer",
                table: "AspNetUsers");
        }
    }
}
