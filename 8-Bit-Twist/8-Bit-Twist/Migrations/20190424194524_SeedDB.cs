using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false),
                    Generation = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Generation", "ImgUrl", "Name", "Price", "ReleaseDate", "SKU" },
                values: new object[,]
                {
                    { 1, "The Nintendo Entertainment System (or NES for short) is an 8-bit home video game console developed and manufactured by Nintendo.", 0, "https://imgur.com/OQ9OfOJ", "Nintendo Entertainment System", 110.00m, "1985-10-18", "NES-111111" },
                    { 2, "The Game Boy[a][b] is an 8-bit handheld game console developed and manufactured by Nintendo.", 0, "https://imgur.com/cInEh1U", "Nintendo GameBoy", 70.00m, "1989-7-31", "GB-111111" },
                    { 3, "The Sega Genesis, known as the Mega Drive[b] in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.", 1, "https://imgur.com/KBXhPpw", "Sega Genesis", 90.00m, "1989-8-14", "SG-111111" },
                    { 4, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.", 1, "https://imgur.com/VZMkb47", "Super Nintendo Entertainment System", 175.00m, "1991-8-23", "SNES-111111" },
                    { 5, "The Game Gear is an 8-bit fourth generation handheld game console released by Sega", 1, "https://imgur.com/9vccdVo", "Sega Game Gear", 50.00m, "1985-10-18", "GG-111111" },
                    { 6, "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.", 1, "https://imgur.com/V1LRlXA", "GameBoy Color", 100.00m, "1998-11-18", "GBC-111111" },
                    { 7, "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.", 2, "https://imgur.com/FvrhEKS", "Sony PlayStation One", 150.00m, "1995-9-9", "PS-111111" },
                    { 8, "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ", 2, "https://imgur.com/TA61Kas", "Nintendo 64", 175.00m, "1996-9-26", "N64-111111" },
                    { 9, "The Sega Saturn is a 32-bit home video game console developed by Sega.", 2, "https://imgur.com/GVsp2KV", "Sega Saturn", 200.00m, "1995-5-11", "SS-111111" },
                    { 10, "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.", 2, "https://imgur.com/GZ57bqX", "GameBoy Advance", 150.00m, "2001-11-6", "GBA-111111" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
