﻿// <auto-generated />
using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("BrandId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"),
                            Name = "Adidas"
                        },
                        new
                        {
                            BrandId = new Guid("9eeee855-eaa8-4828-b65c-4602ee02e058"),
                            Name = "Puma"
                        },
                        new
                        {
                            BrandId = new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"),
                            Name = "Nike"
                        },
                        new
                        {
                            BrandId = new Guid("7b0acaa3-5006-422a-a506-e3b59339fafa"),
                            Name = "Reebok"
                        },
                        new
                        {
                            BrandId = new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"),
                            Name = "Fila"
                        });
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"),
                            Name = "Zapatillas"
                        },
                        new
                        {
                            CategoryId = new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"),
                            Name = "Calzas"
                        },
                        new
                        {
                            CategoryId = new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"),
                            Name = "Buzos"
                        },
                        new
                        {
                            CategoryId = new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"),
                            Name = "Tops"
                        },
                        new
                        {
                            CategoryId = new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"),
                            Name = "Remeras"
                        });
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Audience")
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReviewRate")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("4a908887-e7a4-4b1b-9f7e-32acdfad4c3d"),
                            Audience = 0,
                            Available = true,
                            BrandId = new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"),
                            CategoryId = new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"),
                            Description = "Color Blanco",
                            Name = "Zapatillas Adidas",
                            PictureURL = "",
                            Price = 50000m,
                            ReviewRate = 0
                        },
                        new
                        {
                            ProductId = new Guid("2bb41d94-7894-4db9-b458-405d34abc009"),
                            Audience = 0,
                            Available = true,
                            BrandId = new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"),
                            CategoryId = new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"),
                            Description = "Color Azul",
                            Name = "Buzo Fila",
                            PictureURL = "",
                            Price = 30000m,
                            ReviewRate = 0
                        },
                        new
                        {
                            ProductId = new Guid("33755bf6-4f1a-4e08-a544-4137e81507a7"),
                            Audience = 0,
                            Available = true,
                            BrandId = new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"),
                            CategoryId = new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"),
                            Description = "Color Negro",
                            Name = "Remera Nike",
                            PictureURL = "",
                            Price = 20000m,
                            ReviewRate = 0
                        },
                        new
                        {
                            ProductId = new Guid("d3f6cb84-be38-46f4-834d-0e6485adc750"),
                            Audience = 1,
                            Available = true,
                            BrandId = new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"),
                            CategoryId = new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"),
                            Description = "Color Negro",
                            Name = "Calza Fila Mujer",
                            PictureURL = "",
                            Price = 32000m,
                            ReviewRate = 0
                        },
                        new
                        {
                            ProductId = new Guid("8dfb04b4-e714-4469-bf03-1029ecd7a2c3"),
                            Audience = 1,
                            Available = true,
                            BrandId = new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"),
                            CategoryId = new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"),
                            Description = "Color Blanco",
                            Name = "Top Deportivo Adidas Mujer",
                            PictureURL = "",
                            Price = 15000m,
                            ReviewRate = 0
                        },
                        new
                        {
                            ProductId = new Guid("777da6a0-c9ae-4379-8832-7dfbbd58f260"),
                            Audience = 1,
                            Available = true,
                            BrandId = new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"),
                            CategoryId = new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"),
                            Description = "Color Negro",
                            Name = "Zapatillas Nike Mujer",
                            PictureURL = "",
                            Price = 25000m,
                            ReviewRate = 0
                        });
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.HasOne("API.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("API.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
