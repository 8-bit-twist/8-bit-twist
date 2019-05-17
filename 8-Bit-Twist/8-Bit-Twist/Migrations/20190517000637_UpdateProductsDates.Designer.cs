﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _8_Bit_Twist.Data;

namespace _8_Bit_Twist.Migrations
{
    [DbContext(typeof(_8BitDbContext))]
    [Migration("20190517000637_UpdateProductsDates")]
    partial class UpdateProductsDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Quantity");

                    b.HasKey("BasketID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserID")
                        .IsRequired();

                    b.Property<long>("CardNumber");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<bool>("Completed");

                    b.Property<string>("ShippingAddress")
                        .IsRequired();

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("_8_Bit_Twist.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Generation");

                    b.Property<string>("ImgUrl");

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
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/nes.png",
                            Name = "Nintendo Entertainment System",
                            Price = 1.10m,
                            ReleaseDate = "1985-10-18",
                            SKU = "NES-111111"
                        },
                        new
                        {
                            ID = 2,
                            Description = "The Game Boy is an 8-bit handheld game console developed and manufactured by Nintendo.",
                            Generation = 0,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-boy.png",
                            Name = "Nintendo GameBoy",
                            Price = 0.70m,
                            ReleaseDate = "1989-07-31",
                            SKU = "GB-111111"
                        },
                        new
                        {
                            ID = 3,
                            Description = "The Sega Genesis, known as the Mega Drive in regions outside of North America, is a 16-bit home video game console developed and sold by Sega.",
                            Generation = 1,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/genesis.png",
                            Name = "Sega Genesis",
                            Price = 0.90m,
                            ReleaseDate = "1989-08-14",
                            SKU = "SG-111111"
                        },
                        new
                        {
                            ID = 4,
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo.",
                            Generation = 1,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/snes.png",
                            Name = "Super Nintendo Entertainment System",
                            Price = 1.75m,
                            ReleaseDate = "1991-08-23",
                            SKU = "SNES-111111"
                        },
                        new
                        {
                            ID = 5,
                            Description = "The Game Gear is an 8-bit fourth generation handheld game console released by Sega",
                            Generation = 1,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-gear.png",
                            Name = "Sega Game Gear",
                            Price = 0.50m,
                            ReleaseDate = "1985-10-18",
                            SKU = "GG-111111"
                        },
                        new
                        {
                            ID = 6,
                            Description = "The Game Boy Color (GBC) is a handheld game console manufactured by Nintendo.",
                            Generation = 1,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/game-boy-color.png",
                            Name = "GameBoy Color",
                            Price = 1.00m,
                            ReleaseDate = "1998-11-18",
                            SKU = "GBC-111111"
                        },
                        new
                        {
                            ID = 7,
                            Description = "The PlayStation (officially abbreviated to PS, and commonly known as the PS1 or its codename, PSX) is a home video game console developed and marketed by Sony Computer Entertainment.",
                            Generation = 2,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/playstation.png",
                            Name = "Sony PlayStation One",
                            Price = 1.50m,
                            ReleaseDate = "1995-09-09",
                            SKU = "PS-111111"
                        },
                        new
                        {
                            ID = 8,
                            Description = "The Nintendo 64 (N64), stylized as NINTENDO64, is a home video game console developed and marketed by Nintendo. ",
                            Generation = 2,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/n64.png",
                            Name = "Nintendo 64",
                            Price = 1.75m,
                            ReleaseDate = "1996-09-26",
                            SKU = "N64-111111"
                        },
                        new
                        {
                            ID = 9,
                            Description = "The Sega Saturn is a 32-bit home video game console developed by Sega.",
                            Generation = 2,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/saturn.png",
                            Name = "Sega Saturn",
                            Price = 2.00m,
                            ReleaseDate = "1995-05-11",
                            SKU = "SS-111111"
                        },
                        new
                        {
                            ID = 10,
                            Description = "The Game Boy Advance (GBA) is a 32-bit handheld video game console developed, manufactured and marketed by Nintendo as the successor to the Game Boy Color.",
                            Generation = 2,
                            ImgUrl = "https://8bittwistblob.blob.core.windows.net/products/gb-advance.png",
                            Name = "GameBoy Advance",
                            Price = 1.50m,
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

            modelBuilder.Entity("_8_Bit_Twist.Models.OrderItem", b =>
                {
                    b.HasOne("_8_Bit_Twist.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_8_Bit_Twist.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
