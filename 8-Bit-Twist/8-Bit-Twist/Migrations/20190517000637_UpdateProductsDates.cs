using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class UpdateProductsDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ReleaseDate",
                value: "1985-10-18");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ReleaseDate",
                value: "1989-07-31");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ReleaseDate",
                value: "1989-08-14");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ReleaseDate",
                value: "1991-08-23");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ReleaseDate",
                value: "1985-10-18");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ReleaseDate",
                value: "1998-11-18");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ReleaseDate",
                value: "1995-09-09");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ReleaseDate",
                value: "1996-09-26");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ReleaseDate",
                value: "1995-05-11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ReleaseDate",
                value: "2001-11-6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ReleaseDate",
                value: "10/18/1985");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ReleaseDate",
                value: "7/31/1989");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ReleaseDate",
                value: "8/14/1989");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ReleaseDate",
                value: "8/23/1991");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ReleaseDate",
                value: "10/18/1985");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ReleaseDate",
                value: "11/18/1998");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ReleaseDate",
                value: "9/9/1995");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ReleaseDate",
                value: "9/26/1996");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ReleaseDate",
                value: "5/11/1995");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ReleaseDate",
                value: "11/6/2001");
        }
    }
}
