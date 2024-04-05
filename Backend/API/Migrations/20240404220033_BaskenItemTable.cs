using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class BaskenItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "BasketItem");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "BasketItem",
                newName: "Name");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BasketItem",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BasketItem",
                newName: "ProductName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BasketItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
