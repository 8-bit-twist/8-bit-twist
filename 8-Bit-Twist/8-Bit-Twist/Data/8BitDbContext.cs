using _8_Bit_Twist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Data
{
    public class _8BitDbContext : DbContext
    {
        public _8BitDbContext(DbContextOptions<_8BitDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setup composite keys
            modelBuilder.Entity<BasketItem>().HasKey(ce => new { ce.BasketID, ce.ProductID });
            modelBuilder.Entity<OrderItem>().HasKey(i => new { i.OrderID, i.ProductID});

            // Seed DB with initial 10 products
            // All product descriptions taken from Wikipedia
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    SKU = "NES-111111",
                    Name = "Nintendo Entertainment System",
                    Price = 1.10m,
                    Description = "The Nintendo Entertainment System (or NES for short) is an 8-bit home video game console developed and manufactured by Nintendo.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/nes.png",
                    Generation = Generations.One,
                    ReleaseDate = "1985-10-18",
                },
                new Product
                {
                    ID = 2,
                    SKU = "GB-111111",
                    Name = "Nintendo GameBoy",
                    Price = 0.70m,
                    Description = "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-boy.png",
                    Generation = Generations.One,
                    ReleaseDate = "1989-7-31",
                },
                new Product
                {
                    ID = 3,
                    SKU = "SG-111111",
                    Name = "Sega Genesis",
                    Price = 0.90m,
                    Description = "The Sega Genesis, known as the Mega Drive in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/genesis.png",
                    Generation = Generations.Two,
                    ReleaseDate = "1989-8-14",
                },
                new Product
                {
                    ID = 4,
                    SKU = "SNES-111111",
                    Name = "Super Nintendo Entertainment System",
                    Price = 1.75m,
                    Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/snes.png",
                    Generation = Generations.Two,
                    ReleaseDate = "1991-8-23",
                },
                new Product
                {
                    ID = 5,
                    SKU = "GG-111111",
                    Name = "Sega Game Gear",
                    Price = 0.50m,
                    Description = "The Game Gear is an 8-bit fourth generation handheld game console released by Sega",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-gear.png",
                    Generation = Generations.Two,
                    ReleaseDate = "1985-10-18",
                },
                new Product
                {
                    ID = 6,
                    SKU = "GBC-111111",
                    Name = "GameBoy Color",
                    Price = 1.00m,
                    Description = "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-boy-color.png",
                    Generation = Generations.Two,
                    ReleaseDate = "1998-11-18",
                },
                new Product
                {
                    ID = 7,
                    SKU = "PS-111111",
                    Name = "Sony PlayStation One",
                    Price = 1.50m,
                    Description = "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/playstation.png",
                    Generation = Generations.Three,
                    ReleaseDate = "1995-9-9",
                },
                new Product
                {
                    ID = 8,
                    SKU = "N64-111111",
                    Name = "Nintendo 64",
                    Price = 1.75m,
                    Description = "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/n64.png",
                    Generation = Generations.Three,
                    ReleaseDate = "1996-9-26",
                },
                new Product
                {
                    ID = 9,
                    SKU = "SS-111111",
                    Name = "Sega Saturn",
                    Price = 2.00m,
                    Description = "The Sega Saturn is a 32-bit home video game console developed by Sega.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/saturn.png",
                    Generation = Generations.Three,
                    ReleaseDate = "1995-5-11",
                },
                new Product
                {
                    ID = 10,
                    SKU = "GBA-111111",
                    Name = "GameBoy Advance",
                    Price = 1.50m,
                    Description = "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.",
                    ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/gb-advance.png",
                    Generation = Generations.Three,
                    ReleaseDate = "2001-11-6",
                });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
