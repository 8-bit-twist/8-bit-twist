using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserID = table.Column<string>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    BasketID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => new { x.BasketID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Generation", "ImgUrl", "Name", "Price", "ReleaseDate", "SKU" },
                values: new object[,]
                {
                    { 1, "The Nintendo Entertainment System (or NES for short) is an 8-bit home video game console developed and manufactured by Nintendo.", 0, "/Assets/IMG/Consoles/NES_2Player_Pak__01818.1430494982.jpg", "Nintendo Entertainment System", 110.00m, "1985-10-18", "NES-111111" },
                    { 2, "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.", 0, "/Assets/IMG/Consoles/250px-Game-Boy-FL.jpg", "Nintendo GameBoy", 70.00m, "1989-7-31", "GB-111111" },
                    { 3, "The Sega Genesis, known as the Mega Drive in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.", 1, "/Assets/IMG/Consoles/rBVaSlq7QaiAEpR4AADkruC3mkg294.jpg", "Sega Genesis", 90.00m, "1989-8-14", "SG-111111" },
                    { 4, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.", 1, "/Assets/IMG/Consoles/71itkDwgyyL._SL1500_.jpg", "Super Nintendo Entertainment System", 175.00m, "1991-8-23", "SNES-111111" },
                    { 5, "The Game Gear is an 8-bit fourth generation handheld game console released by Sega", 1, "/Assets/IMG/Consoles/Game-Gear-Handheld.jpg", "Sega Game Gear", 50.00m, "1985-10-18", "GG-111111" },
                    { 6, "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.", 1, "/Assets/IMG/Consoles/300px-Nintendo-Game-Boy-Color-FL.jpg", "GameBoy Color", 100.00m, "1998-11-18", "GBC-111111" },
                    { 7, "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.", 2, "/Assets/IMG/Consoles/PSX-Console-wController.jpg", "Sony PlayStation One", 150.00m, "1995-9-9", "PS-111111" },
                    { 8, "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ", 2, "/Assets/IMG/Consoles/n64.0.png", "Nintendo 64", 175.00m, "1996-9-26", "N64-111111" },
                    { 9, "The Sega Saturn is a 32-bit home video game console developed by Sega.", 2, "/Assets/IMG/Consoles/1200px-Sega-Saturn-Console-Set-Mk1.jpg", "Sega Saturn", 200.00m, "1995-5-11", "SS-111111" },
                    { 10, "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.", 2, "/Assets/IMG/Consoles/Nintendo-Game-Boy-Advance-Purple-FL.jpg", "GameBoy Advance", 150.00m, "2001-11-6", "GBA-111111" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
