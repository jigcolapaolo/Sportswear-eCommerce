using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "BasketItem",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BasketItem",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BasketItem",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "BasketItem",
                newName: "Id");
        }
    }
}
