using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class redoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "The Game Boy[a][b] is an 8-bit handheld game console developed and manufactured by Nintendo.");
        }
    }
}
