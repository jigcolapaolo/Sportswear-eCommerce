using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Gender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2bb41d94-7894-4db9-b458-405d34abc009"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("33755bf6-4f1a-4e08-a544-4137e81507a7"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4a908887-e7a4-4b1b-9f7e-32acdfad4c3d"),
                column: "Gender",
                value: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "BrandId", "CategoryId", "Description", "Gender", "Name", "PictureURL", "Price", "ReviewRate" },
                values: new object[,]
                {
                    { new Guid("777da6a0-c9ae-4379-8832-7dfbbd58f260"), true, new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"), new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"), "Color Negro", 1, "Zapatillas Nike Mujer", "", 25000m, 0 },
                    { new Guid("8dfb04b4-e714-4469-bf03-1029ecd7a2c3"), true, new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"), new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"), "Color Blanco", 1, "Top Deportivo Adidas Mujer", "", 15000m, 0 },
                    { new Guid("d3f6cb84-be38-46f4-834d-0e6485adc750"), true, new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"), new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"), "Color Negro", 1, "Calza Fila Mujer", "", 32000m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("777da6a0-c9ae-4379-8832-7dfbbd58f260"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8dfb04b4-e714-4469-bf03-1029ecd7a2c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d3f6cb84-be38-46f4-834d-0e6485adc750"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");
        }
    }
}
