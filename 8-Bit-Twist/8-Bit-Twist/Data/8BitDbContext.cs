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
                    Price = 110.00m,
                    Description = "The Nintendo Entertainment System (or NES for short) is an 8-bit home video game console developed and manufactured by Nintendo.",
                    ImgUrl = "/Assets/IMG/Consoles/NES_2Player_Pak__01818.1430494982.jpg",
                    Generation = Generations.One,
                    ReleaseDate = "1985-10-18",
                },
                new Product
                {
                    ID = 2,
                    SKU = "GB-111111",
                    Name = "Nintendo GameBoy",
                    Price = 70.00m,
                    Description = "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.",
                    ImgUrl = "/Assets/IMG/Consoles/250px-Game-Boy-FL.jpg",
                    Generation = Generations.One,
                    ReleaseDate = "1989-7-31",
                },
                new Product
                {
                    ID = 3,
                    SKU = "SG-111111",
                    Name = "Sega Genesis",
                    Price = 90.00m,
                    Description = "The Sega Genesis, known as the Mega Drive in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.",
                    ImgUrl = "/Assets/IMG/Consoles/rBVaSlq7QaiAEpR4AADkruC3mkg294.jpg",
                    Generation = Generations.Two,
                    ReleaseDate = "1989-8-14",
                },
                new Product
                {
                    ID = 4,
                    SKU = "SNES-111111",
                    Name = "Super Nintendo Entertainment System",
                    Price = 175.00m,
                    Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.",
                    ImgUrl = "/Assets/IMG/Consoles/71itkDwgyyL._SL1500_.jpg",
                    Generation = Generations.Two,
                    ReleaseDate = "1991-8-23",
                },
                new Product
                {
                    ID = 5,
                    SKU = "GG-111111",
                    Name = "Sega Game Gear",
                    Price = 50.00m,
                    Description = "The Game Gear is an 8-bit fourth generation handheld game console released by Sega",
                    ImgUrl = "/Assets/IMG/Consoles/Game-Gear-Handheld.jpg",
                    Generation = Generations.Two,
                    ReleaseDate = "1985-10-18",
                },
                new Product
                {
                    ID = 6,
                    SKU = "GBC-111111",
                    Name = "GameBoy Color",
                    Price = 100.00m,
                    Description = "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.",
                    ImgUrl = "/Assets/IMG/Consoles/300px-Nintendo-Game-Boy-Color-FL.jpg",
                    Generation = Generations.Two,
                    ReleaseDate = "1998-11-18",
                },
                new Product
                {
                    ID = 7,
                    SKU = "PS-111111",
                    Name = "Sony PlayStation One",
                    Price = 150.00m,
                    Description = "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.",
                    ImgUrl = "/Assets/IMG/Consoles/PSX-Console-wController.jpg",
                    Generation = Generations.Three,
                    ReleaseDate = "1995-9-9",
                },
                new Product
                {
                    ID = 8,
                    SKU = "N64-111111",
                    Name = "Nintendo 64",
                    Price = 175.00m,
                    Description = "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ",
                    ImgUrl = "/Assets/IMG/Consoles/n64.0.png",
                    Generation = Generations.Three,
                    ReleaseDate = "1996-9-26",
                },
                new Product
                {
                    ID = 9,
                    SKU = "SS-111111",
                    Name = "Sega Saturn",
                    Price = 200.00m,
                    Description = "The Sega Saturn is a 32-bit home video game console developed by Sega.",
                    ImgUrl = "/Assets/IMG/Consoles/1200px-Sega-Saturn-Console-Set-Mk1.jpg",
                    Generation = Generations.Three,
                    ReleaseDate = "1995-5-11",
                },
                new Product
                {
                    ID = 10,
                    SKU = "GBA-111111",
                    Name = "GameBoy Advance",
                    Price = 150.00m,
                    Description = "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.",
                    ImgUrl = "/Assets/IMG/Consoles/Nintendo-Game-Boy-Advance-Purple-FL.jpg",
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
