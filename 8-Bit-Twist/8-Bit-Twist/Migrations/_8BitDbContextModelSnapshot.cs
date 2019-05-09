﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _8_Bit_Twist.Data;

namespace _8_Bit_Twist.Migrations
{
    [DbContext(typeof(_8BitDbContext))]
    partial class _8BitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_8_Bit_Twist.Models.Basket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.BasketItem", b =>
                {
                    b.Property<int>("BasketID");

                    b.Property<int>("ProductID");

                    b.Property<int>("ID");

                    b.Property<int>("Quantity");

                    b.HasKey("BasketID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Generation");

                    b.Property<string>("ImgUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("ReleaseDate")
                        .IsRequired();

                    b.Property<string>("SKU")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "The Nintendo Entertainment System (or NES for short) is an 8-bit home video game console developed and manufactured by Nintendo.",
                            Generation = 0,
                            ImgUrl = "/Assets/IMG/Consoles/NES_2Player_Pak__01818.1430494982.jpg",
                            Name = "Nintendo Entertainment System",
                            Price = 110.00m,
                            ReleaseDate = "1985-10-18",
                            SKU = "NES-111111"
                        },
                        new
                        {
                            ID = 2,
                            Description = "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.",
                            Generation = 0,
                            ImgUrl = "/Assets/IMG/Consoles/250px-Game-Boy-FL.jpg",
                            Name = "Nintendo GameBoy",
                            Price = 70.00m,
                            ReleaseDate = "1989-7-31",
                            SKU = "GB-111111"
                        },
                        new
                        {
                            ID = 3,
                            Description = "The Sega Genesis, known as the Mega Drive[b] in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.",
                            Generation = 1,
                            ImgUrl = "/Assets/IMG/Consoles/rBVaSlq7QaiAEpR4AADkruC3mkg294.jpg",
                            Name = "Sega Genesis",
                            Price = 90.00m,
                            ReleaseDate = "1989-8-14",
                            SKU = "SG-111111"
                        },
                        new
                        {
                            ID = 4,
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.",
                            Generation = 1,
                            ImgUrl = "/Assets/IMG/Consoles/71itkDwgyyL._SL1500_.jpg",
                            Name = "Super Nintendo Entertainment System",
                            Price = 175.00m,
                            ReleaseDate = "1991-8-23",
                            SKU = "SNES-111111"
                        },
                        new
                        {
                            ID = 5,
                            Description = "The Game Gear is an 8-bit fourth generation handheld game console released by Sega",
                            Generation = 1,
                            ImgUrl = "/Assets/IMG/Consoles/Game-Gear-Handheld.jpg",
                            Name = "Sega Game Gear",
                            Price = 50.00m,
                            ReleaseDate = "1985-10-18",
                            SKU = "GG-111111"
                        },
                        new
                        {
                            ID = 6,
                            Description = "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.",
                            Generation = 1,
                            ImgUrl = "/Assets/IMG/Consoles/300px-Nintendo-Game-Boy-Color-FL.jpg",
                            Name = "GameBoy Color",
                            Price = 100.00m,
                            ReleaseDate = "1998-11-18",
                            SKU = "GBC-111111"
                        },
                        new
                        {
                            ID = 7,
                            Description = "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.",
                            Generation = 2,
                            ImgUrl = "/Assets/IMG/Consoles/PSX-Console-wController.jpg",
                            Name = "Sony PlayStation One",
                            Price = 150.00m,
                            ReleaseDate = "1995-9-9",
                            SKU = "PS-111111"
                        },
                        new
                        {
                            ID = 8,
                            Description = "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ",
                            Generation = 2,
                            ImgUrl = "/Assets/IMG/Consoles/n64.0.png",
                            Name = "Nintendo 64",
                            Price = 175.00m,
                            ReleaseDate = "1996-9-26",
                            SKU = "N64-111111"
                        },
                        new
                        {
                            ID = 9,
                            Description = "The Sega Saturn is a 32-bit home video game console developed by Sega.",
                            Generation = 2,
                            ImgUrl = "/Assets/IMG/Consoles/1200px-Sega-Saturn-Console-Set-Mk1.jpg",
                            Name = "Sega Saturn",
                            Price = 200.00m,
                            ReleaseDate = "1995-5-11",
                            SKU = "SS-111111"
                        },
                        new
                        {
                            ID = 10,
                            Description = "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.",
                            Generation = 2,
                            ImgUrl = "/Assets/IMG/Consoles/Nintendo-Game-Boy-Advance-Purple-FL.jpg",
                            Name = "GameBoy Advance",
                            Price = 150.00m,
                            ReleaseDate = "2001-11-6",
                            SKU = "GBA-111111"
                        });
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.BasketItem", b =>
                {
                    b.HasOne("_8_Bit_Twist.Models.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_8_Bit_Twist.Models.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
