﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewRate = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"), "Nike" },
                    { new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"), "Fila" },
                    { new Guid("7b0acaa3-5006-422a-a506-e3b59339fafa"), "Reebok" },
                    { new Guid("9eeee855-eaa8-4828-b65c-4602ee02e058"), "Puma" },
                    { new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"), "Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"), "Tops" },
                    { new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"), "Zapatillas" },
                    { new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"), "Remeras" },
                    { new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"), "Buzos" },
                    { new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"), "Calzas" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "BrandId", "CategoryId", "Description", "Name", "PictureURL", "Price", "ReviewRate" },
                values: new object[,]
                {
                    { new Guid("2bb41d94-7894-4db9-b458-405d34abc009"), true, new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"), new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"), "Color Azul", "Buzo Fila", "", 30000m, 0 },
                    { new Guid("33755bf6-4f1a-4e08-a544-4137e81507a7"), true, new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"), new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"), "Color Negro", "Remera Nike", "", 20000m, 0 },
                    { new Guid("4a908887-e7a4-4b1b-9f7e-32acdfad4c3d"), true, new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"), new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"), "Color Blanco", "Zapatillas Adidas", "", 50000m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
