using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    PictureURL = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ReviewRate = table.Column<int>(type: "integer", nullable: false),
                    Audience = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrdersOrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
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
                columns: new[] { "ProductId", "Audience", "Available", "BrandId", "CategoryId", "Description", "Name", "PictureURL", "Price", "ReviewRate" },
                values: new object[,]
                {
                    { new Guid("2bb41d94-7894-4db9-b458-405d34abc009"), 0, true, new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"), new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"), "Color Azul", "Buzo Fila", "", 30000m, 0 },
                    { new Guid("33755bf6-4f1a-4e08-a544-4137e81507a7"), 0, true, new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"), new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"), "Color Negro", "Remera Nike", "", 20000m, 0 },
                    { new Guid("4a908887-e7a4-4b1b-9f7e-32acdfad4c3d"), 0, true, new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"), new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"), "Color Blanco", "Zapatillas Adidas", "", 50000m, 0 },
                    { new Guid("777da6a0-c9ae-4379-8832-7dfbbd58f260"), 1, true, new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"), new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"), "Color Negro", "Zapatillas Nike Mujer", "", 25000m, 0 },
                    { new Guid("8dfb04b4-e714-4469-bf03-1029ecd7a2c3"), 1, true, new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"), new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"), "Color Blanco", "Top Deportivo Adidas Mujer", "", 15000m, 0 },
                    { new Guid("d3f6cb84-be38-46f4-834d-0e6485adc750"), 1, true, new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"), new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"), "Color Negro", "Calza Fila Mujer", "", 32000m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersOrderId",
                table: "OrderItems",
                column: "OrdersOrderId");

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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
