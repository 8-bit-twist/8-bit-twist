using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class updatedproductimgurls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/NES_2Player_Pak__01818.1430494982.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/250px-Game-Boy-FL.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/rBVaSlq7QaiAEpR4AADkruC3mkg294.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/71itkDwgyyL._SL1500_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/Game-Gear-Handheld.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/300px-Nintendo-Game-Boy-Color-FL.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/PSX-Console-wController.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/n64.0.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/1200px-Sega-Saturn-Console-Set-Mk1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImgUrl",
                value: "/Assets/IMG/Consoles/Nintendo-Game-Boy-Advance-Purple-FL.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://imgur.com/OQ9OfOJ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://imgur.com/cInEh1U");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://imgur.com/KBXhPpw");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://imgur.com/VZMkb47");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://imgur.com/9vccdVo");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://imgur.com/V1LRlXA");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://imgur.com/FvrhEKS");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://imgur.com/TA61Kas");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://imgur.com/GVsp2KV");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://imgur.com/GZ57bqX");
        }
    }
}
