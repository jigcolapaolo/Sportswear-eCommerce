using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "CustomerBaskets",
                columns: table => new
                {
                    CustomerBasketId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBaskets", x => x.CustomerBasketId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                name: "BasketItem",
                columns: table => new
                {
                    BasketItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CustomerBasketId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.BasketItemId);
                    table.ForeignKey(
                        name: "FK_BasketItem_CustomerBaskets_CustomerBasketId",
                        column: x => x.CustomerBasketId,
                        principalTable: "CustomerBaskets",
                        principalColumn: "CustomerBasketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PictureUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureUrls_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), "Adidas" },
                    { new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), "Fila" },
                    { new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), "Puma" },
                    { new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), "Nike" },
                    { new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), "Reebok" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Zapatillas" },
                    { new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Calzas" },
                    { new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Remeras" },
                    { new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Buzos y Camperas" },
                    { new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Tops" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Audience", "Available", "BrandId", "CategoryId", "Description", "Name", "Price", "ReviewRate" },
                values: new object[,]
                {
                    { new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul para hombre.", "Zapatillas Fluidstreet Adidas", 143000m, 0 },
                    { new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Calza corta, color negro para mujer.", "Calza Reebok Fit", 49500m, 0 },
                    { new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para hombre.", "Buzo Reebok Sportswear", 140000m, 0 },
                    { new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), 3, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco y rosa para niñas.", "Zapatillas Reebok Classic Jogger", 105000m, 0 },
                    { new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color azul para hombre.", "Remera Adidas Essentials", 50000m, 0 },
                    { new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), 2, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Remera manga larga, color negro para niños.", "Remera Nike Basic", 44000m, 0 },
                    { new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para mujer.", "Buzo Nike SportOn", 130000m, 0 },
                    { new Guid("0c92c422-5970-430e-a2b7-800313abf519"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para mujer.", "Remera Puma Classics", 57000m, 0 },
                    { new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), 0, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Remera manga larga, color negro para hombre.", "Remera Nike Dry Fit", 54000m, 0 },
                    { new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color negro para mujer.", "Calza Adicolor Adidas", 72000m, 0 },
                    { new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color negro para mujer.", "Calza Nike Air", 83000m, 0 },
                    { new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), 3, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color rosa para niñas.", "Zapatillas Adidas Altarun", 115000m, 0 },
                    { new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro, blanco y beige para mujer.", "Zapatillas Puma Platinum", 165000m, 0 },
                    { new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Puma Keeps", 99000m, 0 },
                    { new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color salmón para mujer.", "Remera Adidas Run", 54500m, 0 },
                    { new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro y lila para mujer.", "Remera Adidas Tiro", 60000m, 0 },
                    { new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Nike Pro", 81000m, 0 },
                    { new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color salmón para mujer.", "Zapatillas Reebok Liquifect", 193000m, 0 },
                    { new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color gris para hombre.", "Remera Reebok Classic Soft", 54000m, 0 },
                    { new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Buzo corto color marrón, para mujer", "Buzo Aeroready Adidas", 140000m, 0 },
                    { new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul y rosa para mujer.", "Zapatillas Reebok Lite Plus", 142000m, 0 },
                    { new Guid("39e394fc-1afe-4969-8064-bc196834af14"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color gris y blanco para hombre.", "Zapatillas Reebok Flexagon", 153000m, 0 },
                    { new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Con capucha, color gris, felpa, para hombre.", "Buzo Adidas Essentials", 110000m, 0 },
                    { new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Buzo corto color rosa para mujer.", "Buzo Crop Fila", 130000m, 0 },
                    { new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para hombre.", "Remera Reebok Graphic Series", 64500m, 0 },
                    { new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), 2, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para niños.", "Buzo Adidas Originals", 99000m, 0 },
                    { new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), 2, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro y amarillo para niños.", "Buzo Puma Mini", 110500m, 0 },
                    { new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color naranja con animal print para mujer.", "Calza Adidas Rich", 95000m, 0 },
                    { new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color lavanda para mujer.", "Zapatillas Puma Flyer Runner", 178000m, 0 },
                    { new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), 2, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro y blanco para niños.", "Zapatillas Puma Rebound", 113000m, 0 },
                    { new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color blanco para mujer.", "Top Fila Essentials", 81000m, 0 },
                    { new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), 2, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul y negro para niños.", "Zapatillas Nike Hustle", 120000m, 0 },
                    { new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para mujer.", "Buzo Reebok VTF", 169000m, 0 },
                    { new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), 3, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para niñas.", "Buzo Nike Mini", 123000m, 0 },
                    { new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco y rosa para mujer.", "Zapatillas Nike Air Pegasus", 160000m, 0 },
                    { new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para mujer.", "Buzo Puma Black", 160500m, 0 },
                    { new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro, gris y lavanda para mujer.", "Zapatillas Nike Trainer", 185000m, 0 },
                    { new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco y negro para hombre.", "Zapatillas Puma Taper", 163000m, 0 },
                    { new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color aguamarina para mujer.", "Zapatillas Adidas Runfalcon", 132000m, 0 },
                    { new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul, verde y blanco para hombre.", "Zapatillas Magnus Fila", 178000m, 0 },
                    { new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Calza corta, color negro para mujer.", "Calza Nike Essentials", 58000m, 0 },
                    { new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color verde claro para hombre.", "Buzo Puma Green", 174000m, 0 },
                    { new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para hombre.", "Buzo Fila New Letter", 142000m, 0 },
                    { new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), 2, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul, blanco y amarillo para niños.", "Zapatillas Reebok Royal", 105000m, 0 },
                    { new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color negro para hombre.", "Calzas Own the Run Adidas", 115000m, 0 },
                    { new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Calza corta, color negro para mujer.", "Calza Fila Flat", 48000m, 0 },
                    { new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para mujer.", "Remera Fila Basic", 48000m, 0 },
                    { new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), 0, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro para hombre.", "Zapatillas Nike Flex", 168000m, 0 },
                    { new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), 0, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro, azul y beige para hombre.", "Zapatillas Nike Legend Essential", 175000m, 0 },
                    { new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Puma Mid Impact", 76000m, 0 },
                    { new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), 3, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color rosa para niñas.", "Zapatillas Disruptor Fila", 130000m, 0 },
                    { new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color negro y gris para hombre", "Zapatillas Racer One Fila", 163000m, 0 },
                    { new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), 3, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color rosa para niñas.", "Remera Adidas Essentials", 52000m, 0 },
                    { new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color celeste para mujer.", "Remera Reebok Classic", 59000m, 0 },
                    { new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para mujer.", "Buzo Nike Flex", 180000m, 0 },
                    { new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color azul para hombre.", "Remera G Fila", 60500m, 0 },
                    { new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), 2, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco y azul para niños.", "Zapatillas Adidas Altasport", 115000m, 0 },
                    { new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Con capucha, color azul, logo naranja, para hombre.", "Big Boss Buzo Adidas", 130000m, 0 },
                    { new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color verde claro para mujer.", "Remera Nike Dry Fit", 60500m, 0 },
                    { new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), 0, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color blanco para hombre.", "Remeras Nike SportOn", 68000m, 0 },
                    { new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color azul, blanco y rosa para hombre.", "Buzo Fila Net", 120500m, 0 },
                    { new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Remera manga larga, color negro para mujer.", "Remera Mindfull Fila", 57000m, 0 },
                    { new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color gris para mujer.", "Top Fila Essentials", 87000m, 0 },
                    { new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color aguamarina para mujer.", "Top Reebok ColorFit", 105000m, 0 },
                    { new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), 3, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color blanco para niñas.", "Remera Nike Sportswear", 44000m, 0 },
                    { new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color naranja para hombre.", "Remera Adidas Run", 52000m, 0 },
                    { new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color negro para hombre.", "Calza Flex Fila", 52000m, 0 },
                    { new Guid("a64d4099-646e-4691-9e48-76726984e83d"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para hombre.", "Remera Puma Rudagon", 53500m, 0 },
                    { new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color blanco para mujer.", "Remera Puma Classics", 59000m, 0 },
                    { new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para hombre.", "Remera Puma Core", 49000m, 0 },
                    { new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color rosa para mujer.", "Zapatillas Fila Orbit", 174000m, 0 },
                    { new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), 2, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color blanco para niños.", "Remera Fila Basic", 49000m, 0 },
                    { new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para hombre.", "Buzo Puma Black", 130000m, 0 },
                    { new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color negro para mujer.", "Calza Puma Active", 58000m, 0 },
                    { new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), 3, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color rosa para niñas.", "Buzo Puma Mini", 110500m, 0 },
                    { new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color beige y rosa para mujer.", "Zapatillas Racer One Fila", 158000m, 0 },
                    { new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), 3, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color amarillo para niñas.", "Remera Puma x Bob Esponja", 45000m, 0 },
                    { new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), 0, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color turquesa oscuro para hombre.", "Buzo Nike Sportwear", 163000m, 0 },
                    { new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), 2, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco, negro y rojo para niños.", "Zapatillas Vulcan Fila", 130000m, 0 },
                    { new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), 3, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color lila para niñas.", "Remera Vector Fila", 49000m, 0 },
                    { new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color beige para mujer.", "Top Nike Sportswear", 82000m, 0 },
                    { new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color bordo y blanco para mujer.", "Calza Puma Run", 55000m, 0 },
                    { new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color gris camo para mujer.", "Calza Reebok Workout Ready", 54000m, 0 },
                    { new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color azul rey, para mujer.", "Soft Luxe Buzo Adidas", 120000m, 0 },
                    { new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para mujer.", "Remera Reebok Burnout", 69000m, 0 },
                    { new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"), "Color gris para mujer.", "Calza Fila Tenis", 54000m, 0 },
                    { new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), 0, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color rojo para hombre.", "Zapatillas Puma Comet", 189000m, 0 },
                    { new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), 3, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color blanco y rosa para niñas.", "Zapatillas Nike Pico", 120000m, 0 },
                    { new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), 3, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Campera color verde para niñas.", "Campera Adicolor Adidas", 110000m, 0 },
                    { new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), 1, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para mujer.", "Remera Nike Miler", 58000m, 0 },
                    { new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), 1, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color azul, blanco y rojo para mujer.", "Buzo Fila Sweet", 138000m, 0 },
                    { new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), 1, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color verde militar para mujer.", "Buzo Puma Mili", 145000m, 0 },
                    { new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color celeste y negro para hombre.", "Zapatillas Reebok Forever", 169000m, 0 },
                    { new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color celeste para mujer.", "Zapatillas Adidas Ultimateshow", 156000m, 0 },
                    { new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), 0, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color azul para hombre.", "Buzo Reebok VTM", 173000m, 0 },
                    { new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), 2, true, new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para niños.", "Campera Nike Mini", 125000m, 0 },
                    { new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Adidas Essentials", 65000m, 0 },
                    { new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), 0, true, new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color celeste para hombre.", "Remera Australian Fila", 61000m, 0 },
                    { new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), 2, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color blanco para niños.", "Remera Puma x Bob Esponja", 45000m, 0 },
                    { new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), 3, true, new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color rosa para niñas.", "Zapatillas Puma Comet", 113000m, 0 },
                    { new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), 2, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"), "Color negro para niños.", "Remera Trefoil Adidas", 52000m, 0 },
                    { new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Reebok Flex", 99000m, 0 },
                    { new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), 1, true, new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"), new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"), "Color negro para mujer.", "Buzo Reebok Sportswear", 140000m, 0 },
                    { new Guid("fb25a719-2394-4987-b092-715e9f44005a"), 1, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("62345277-d424-48ea-ace2-432e35c93d58"), "Color negro para mujer.", "Top Adidas Alpha", 80000m, 0 },
                    { new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), 0, true, new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"), new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"), "Color azul y naranja para hombre.", "Zapatillas Adidas Galaxy", 120000m, 0 }
                });

            migrationBuilder.InsertData(
                table: "PictureUrls",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("009fbc87-b060-4f50-a07e-4f6338a9b2bf"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-2.png" },
                    { new Guid("00e39cfc-f341-440e-ad88-d6b89497e615"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-2.png" },
                    { new Guid("01ca48f8-b0ab-421d-b253-ae2883dfaedf"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-2.png" },
                    { new Guid("0377dc9a-3818-4646-b451-74adbb2eb9ad"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-2.png" },
                    { new Guid("03880834-1181-461e-b981-ce37a1c3043e"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-1.png" },
                    { new Guid("0491e78d-d045-42f8-b1cc-984eee329737"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-3.png" },
                    { new Guid("04a389d4-438a-4c0e-aa91-8df1ff1b12eb"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-2.png" },
                    { new Guid("05c25ce2-f43f-4d99-bbb5-39163cb2f2e8"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-1.png" },
                    { new Guid("06344f71-100c-4347-8986-e03833943082"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-3.png" },
                    { new Guid("074c5f7d-9aeb-4400-9af8-a87df1317ce2"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-2.png" },
                    { new Guid("0896c6c5-93fb-417e-b29e-b5aa33652642"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-2.png" },
                    { new Guid("0a479172-964d-4910-a166-03dbcd0fae20"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-2.png" },
                    { new Guid("0b635e21-f953-4452-960b-efe002c23b32"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-1.png" },
                    { new Guid("0b85f2a8-1567-42bc-b89c-832e54238b07"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-3.png" },
                    { new Guid("0cb7d460-4b09-424f-b38b-af4a3137c9b1"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-3.png" },
                    { new Guid("0cfc65ae-a7ed-4ab1-afdc-5c3270044e4b"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-3.png" },
                    { new Guid("0d544b1e-bb21-4191-b84c-6bff883124fa"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-3.png" },
                    { new Guid("0ec0ce2e-d09a-4aea-a545-e7e4da6fefd2"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-2.png" },
                    { new Guid("0f70d155-be75-4bf5-9a28-2bbb4e58bb7a"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-2.png" },
                    { new Guid("124b563e-2558-419b-a7ca-335f9e1443fd"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-2.png" },
                    { new Guid("12b16a13-a364-45b2-ad60-0d7b02c2a7a4"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-3.png" },
                    { new Guid("137bd8f3-11a3-4442-ba2e-31d05eba3e5b"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-1.png" },
                    { new Guid("13d3ff99-c7e1-4c89-9360-7f29faab2aa5"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-3.png" },
                    { new Guid("13ed5dcc-2172-4981-a695-db0b73595db2"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-1.png" },
                    { new Guid("1412ebb8-031b-4153-aa7c-52a3b3c49831"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-3.png" },
                    { new Guid("156b929d-2210-424f-bea9-86e1c2391519"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-3.png" },
                    { new Guid("16b40925-4529-4407-a5c4-c243406b0a9f"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-3.png" },
                    { new Guid("16e5bc07-e6a8-4443-a08b-d89829bada0d"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-3.png" },
                    { new Guid("19021c62-e3d3-4087-ac03-4b9188754832"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-3.png" },
                    { new Guid("19091b10-fc54-483a-8e63-b4ad2a60491c"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-2.png" },
                    { new Guid("1947a4db-780e-4d6b-95b0-c463dddd3af3"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-1.png" },
                    { new Guid("1a5fd540-c9d1-4f80-9426-ecd0e4c27f7f"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-1.png" },
                    { new Guid("1b3265ff-3982-44ff-ada8-e8086fd0e328"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-2.png" },
                    { new Guid("1b7565dc-b4cd-44fe-b46d-10b56f7335ca"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-3.png" },
                    { new Guid("1bff905b-bf78-4c16-849e-70ec9ba9670f"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-2.png" },
                    { new Guid("1c025b24-098e-431d-bc6d-f9442f99330f"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-3.png" },
                    { new Guid("1ced0173-ba1b-41e4-8724-a3edf9de6a77"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-2.png" },
                    { new Guid("1fbf35d2-5d94-4d05-b444-dcbada1f8c19"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-1.png" },
                    { new Guid("1fe78173-57a2-4dca-a276-d709e65f5734"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-1.png" },
                    { new Guid("22062dac-26a5-418d-820e-16fb51adced2"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-2.png" },
                    { new Guid("223d99f3-4c9b-416f-9c9e-c7bd3c120c21"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-1.png" },
                    { new Guid("2356665e-cca4-47a8-a37f-cd382f450a44"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-2.png" },
                    { new Guid("24020ffc-e0b6-49a9-8656-5457d2f7dfd9"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-2.png" },
                    { new Guid("245ac821-0b45-4738-9a04-215fbd7c2de8"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-1.png" },
                    { new Guid("26fe10c4-bcad-48d6-9884-2f77ff242ef9"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-1.png" },
                    { new Guid("2725b2d3-9614-4a75-afa3-0e2195407bac"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-2.png" },
                    { new Guid("28125e87-5c62-445c-ada0-bdb42f75c5c0"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-2.png" },
                    { new Guid("28a8b22f-6944-484e-af1e-e385905e8419"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-3.png" },
                    { new Guid("298ace4e-88b5-41b3-aa4a-65dafb60e0c0"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-2.png" },
                    { new Guid("2afb9668-88ac-4617-9515-6beaee3a8f91"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-1.png" },
                    { new Guid("2b4cbcf5-1b52-4f9e-8491-35bb5af60acf"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-3.png" },
                    { new Guid("2b70c658-2ce8-45e0-8e99-5b12395095f0"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-3.png" },
                    { new Guid("2b7e281f-b5cb-458d-a311-c475ffe03a93"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-2.png" },
                    { new Guid("2beb0782-2de8-488c-9758-805b03241408"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-1.png" },
                    { new Guid("2c7e2f1e-4985-458f-8984-9a68f0e14fcd"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-3.png" },
                    { new Guid("2f511807-4735-4a15-bb9e-94ae8f69c0de"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-1.png" },
                    { new Guid("31f12c27-d826-4f31-8b72-6fb558cf797d"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-1.png" },
                    { new Guid("33bf9a76-e314-4bac-b391-27445b80c702"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-3.png" },
                    { new Guid("33d3a96d-3d93-46e7-809e-cb6ed6dcbad2"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-3.png" },
                    { new Guid("35885af9-4565-47e7-80bb-03e4a68df814"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-3.png" },
                    { new Guid("362e09bd-1e67-40f3-ba24-9ef65b62f905"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-3.png" },
                    { new Guid("3648cca7-bb09-4f4f-bd97-74d2df5d325d"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-1.png" },
                    { new Guid("36c57dde-88db-43c5-b18e-0a86b15fb23c"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-3.png" },
                    { new Guid("37bbc9a6-9c63-43d8-9276-e442cb96f32d"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-3.png" },
                    { new Guid("3909ee04-0ac6-409a-8d7b-714ba19f1a75"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-1.png" },
                    { new Guid("3c904aff-37b8-435e-981e-5ddd64a5b9f7"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-3.png" },
                    { new Guid("3ed5ac7e-108e-4918-8095-e93a3a40a1cb"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-1.png" },
                    { new Guid("3fadd83a-6b1c-4219-9fa0-bf3747926cab"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-2.png" },
                    { new Guid("3fe1607b-9945-4d11-852c-bb7176b7ce78"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-1.png" },
                    { new Guid("4054c3d5-d120-4154-a100-f10008f44ee2"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-2.png" },
                    { new Guid("409418d4-a0fa-4ee2-a97f-79ee364ed479"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-2.png" },
                    { new Guid("40f7a133-ca54-4115-91cc-25ea5caf9578"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-1.png" },
                    { new Guid("41125713-b416-4c80-b93d-db756645560c"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-2.png" },
                    { new Guid("41a414e7-8125-4592-aef0-6fd350e61b3b"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-2.png" },
                    { new Guid("422b78cd-52d4-42fe-960a-0c16dc35e8b8"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-2.png" },
                    { new Guid("425940fe-3fc6-4591-b8f2-42ae3e5203bb"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-3.png" },
                    { new Guid("4598a3a1-99e6-4c30-afda-e9176c91d807"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-2.png" },
                    { new Guid("464d204c-755b-48ca-bc2e-f3d542719004"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-3.png" },
                    { new Guid("4b81d7c0-44a3-4eeb-bbff-bf4d90d1688b"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-1.png" },
                    { new Guid("4bd3319d-641e-4297-b51d-2b6b852b9b8f"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-3.png" },
                    { new Guid("4c0c8646-c164-45f1-8e79-7ad4aa9db03c"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-3.png" },
                    { new Guid("4c899f6e-11d3-4a72-895d-43b9d156ba86"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-3.png" },
                    { new Guid("508014e0-2c19-4cf7-8b91-78b95052cd73"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-3.png" },
                    { new Guid("51641847-4ddb-4941-9b69-1ce7715c043c"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-3.png" },
                    { new Guid("522045bc-4a34-420d-b0fb-9276bc86bf0b"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-2.png" },
                    { new Guid("537a2c89-58ac-4702-a9f9-3424cc73fe86"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-3.png" },
                    { new Guid("53c9227d-6f40-4eca-890d-92673a8d6062"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-1.png" },
                    { new Guid("54e68cb6-f534-44d2-97c6-db675d0c0ce6"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-3.png" },
                    { new Guid("557a0c11-7ea4-4470-b675-9bccf6009eb9"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-2.png" },
                    { new Guid("559d9666-9602-4009-93a7-be214be8f6f0"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-3.png" },
                    { new Guid("57ce9a3e-8833-4256-9d33-c8ab1e8b5982"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-2.png" },
                    { new Guid("585fcf4d-d585-44f7-8846-89af4db6d814"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-2.png" },
                    { new Guid("588445ab-7f69-4ec8-8c05-39ed4aa9053a"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-1.png" },
                    { new Guid("5898721c-6c0b-4546-8b88-dfbd5391e0d2"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-3.png" },
                    { new Guid("58b731f6-fdca-4e56-bd70-ea7d8a6c7e48"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-3.png" },
                    { new Guid("5903d382-7650-4947-a530-a06c274f0bdf"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-1.png" },
                    { new Guid("59ace5bd-0484-4f1b-9add-5de768d34063"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-3.png" },
                    { new Guid("5a24dc86-8f3a-4f05-a90a-ce1209e88cc3"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-1.png" },
                    { new Guid("5aedd73d-06f8-47f2-be05-91c7b414994f"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-3.png" },
                    { new Guid("5b316676-0013-4f6e-8bd8-a4d161f6b6df"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-1.png" },
                    { new Guid("5be84df0-3597-45d5-ae93-757c21c0e322"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-1.png" },
                    { new Guid("5ddefd0b-f90a-4fa5-b24b-e793d321e7ff"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-3.png" },
                    { new Guid("5e195d91-dcc5-4c01-bdea-b9f39c7fdb71"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-1.png" },
                    { new Guid("5f18462c-337b-4d7b-8a9c-dd24d5eb842b"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-2.png" },
                    { new Guid("5f3aba09-892d-4a0c-95f0-c02b8d4c46f9"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-3.png" },
                    { new Guid("5ff64c1c-4577-4736-a4ac-d61c8eef311a"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-3.png" },
                    { new Guid("61770ecb-6e67-4dfd-9f29-676828bf2a24"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-1.png" },
                    { new Guid("6202a387-e649-4f5e-9d91-47d31a1e2da3"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-1.png" },
                    { new Guid("62098851-3678-4363-a288-dd4a13a1afa3"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-1.png" },
                    { new Guid("62c075cf-f47e-49e1-b384-553ca8df350a"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-3.png" },
                    { new Guid("6327edde-7741-4ceb-93c7-48c44d37e681"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-2.png" },
                    { new Guid("6362380a-f949-4f1a-8ded-a34b43eaeb59"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-2.png" },
                    { new Guid("64c15630-4f2a-45e9-aad1-4546b4923501"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-1.png" },
                    { new Guid("65018492-ce83-4096-ab36-ed9962f1b410"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-1.png" },
                    { new Guid("6574683f-e073-4258-bc67-2b25a944789c"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-1.png" },
                    { new Guid("66157a7d-10fc-4e3a-acf0-685835aa3bef"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-2.png" },
                    { new Guid("66873b6b-a0e7-41f3-b205-c2c43102e187"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-1.png" },
                    { new Guid("668e7a18-107e-4a4c-a89f-2da6233983b8"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-2.png" },
                    { new Guid("66fe952a-1a9e-4369-9a37-f5ca4414f618"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-1.png" },
                    { new Guid("67a91321-38b0-4bad-82ba-5e240487b6f4"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-1.png" },
                    { new Guid("6819c732-3bc8-4c2f-80cf-5a97bbe62953"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-2.png" },
                    { new Guid("6877e8e1-e5d7-437d-938a-d135bd290b9e"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-1.png" },
                    { new Guid("689842cb-1817-48e0-bf9b-0b06bdbbadfc"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-2.png" },
                    { new Guid("68a57e86-4344-403e-80c8-56cc5078c2f5"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-3.png" },
                    { new Guid("68c07ca8-c174-408b-9df5-d82c4f2cb10f"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-2.png" },
                    { new Guid("68ff33d2-1ac7-4310-a2dc-b8501a750340"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-2.png" },
                    { new Guid("69807bcb-1d13-43c4-b141-fe50e5e80f09"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-1.png" },
                    { new Guid("6a0e2c1c-83bf-47d9-a114-98505b2d73b0"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-2.png" },
                    { new Guid("6be98527-2a47-4066-b4f3-1f99251e9b10"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-1.png" },
                    { new Guid("6d87ec47-b057-4fcf-a948-3c45238a9295"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-2.png" },
                    { new Guid("6ddaa26e-edce-4a18-97bd-020ce7feb9b8"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-1.png" },
                    { new Guid("6e209dac-c974-42bb-80ae-0a49018da6f6"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-3.png" },
                    { new Guid("6e4073a9-e098-43ca-a6e6-e2d2e5d0f4ac"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-3.png" },
                    { new Guid("6fc4cc35-15af-48ec-8303-42e2964d51f8"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-2.png" },
                    { new Guid("6ff0978e-3bbf-4b60-a3af-8624018d4765"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-1.png" },
                    { new Guid("7010a7c4-e80d-4a5d-9ba2-974d4907706a"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-3.png" },
                    { new Guid("702caa71-cedd-4d0a-8ff1-fbdc7f6a7633"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-2.png" },
                    { new Guid("7061d59c-c7ba-4d3d-8fdd-c06ede9aff4d"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-3.png" },
                    { new Guid("708488da-d621-4358-9366-564551b33d7e"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-1.png" },
                    { new Guid("717701d1-227f-4556-9f9a-61e350e7714f"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-1.png" },
                    { new Guid("721150a1-44f0-4105-a2c8-cb1e4769f9d0"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-3.png" },
                    { new Guid("72f5a4ef-01a5-44ea-ad07-c592e480c8de"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-1.png" },
                    { new Guid("7329aea5-2ff4-449c-8327-f2d1e8b9a5ae"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-2.png" },
                    { new Guid("735ca8f6-bc81-4840-bfb3-6e175ab0524b"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-3.png" },
                    { new Guid("73bdc916-df0a-442c-87a3-28e56e9175d0"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-1.png" },
                    { new Guid("796cbd34-3328-4fe2-87b8-a8208ec76cfe"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-1.png" },
                    { new Guid("7a68c6a1-12b4-4504-b61a-d2b2c8be061f"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-1.png" },
                    { new Guid("7b419611-72ee-4fd3-b85d-fe9fd64f14f8"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("7be0ceb7-77e8-4d16-9221-b121e36097bb"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-3.png" },
                    { new Guid("7cfa399b-521a-4f27-b6ab-d30d5e7ef499"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-3.png" },
                    { new Guid("8158149b-9c8b-469e-b35b-babb865661d3"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-3.png" },
                    { new Guid("8192d2f8-0429-4927-aeac-fb2a445014f0"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-1.png" },
                    { new Guid("81ba1602-6ef1-4992-a7f0-1c01b6935add"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-2.png" },
                    { new Guid("83b1d102-f7fd-4bdd-8377-3c496cc16bc7"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-3.png" },
                    { new Guid("8464b929-7ee4-4057-b57b-5bc0fa72e4db"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-2.png" },
                    { new Guid("853a63b3-4fda-4d07-a15b-46ef876b9c54"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-1.png" },
                    { new Guid("865935df-107b-4257-bdff-fc325a6108fe"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-1.png" },
                    { new Guid("869cdbbe-234d-433f-85cc-3d14f09b08e7"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-1.png" },
                    { new Guid("86f34da8-259c-4d42-bc85-603c95af0f08"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-1.png" },
                    { new Guid("879e9d6a-4122-43d3-8e17-16fd076b24b0"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-1.png" },
                    { new Guid("87c41dfe-c9b1-4d75-b457-641a97b1e295"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-1.png" },
                    { new Guid("88f66f57-2309-42e6-9af1-c7368d6b8964"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-3.png" },
                    { new Guid("89022f85-f3db-440d-8bca-681c2f6879cf"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-1.png" },
                    { new Guid("8967b001-875a-4f94-b253-b881445619a3"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-2.png" },
                    { new Guid("8a092e18-dc2b-47b2-ab77-e42e2e577e43"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-1.png" },
                    { new Guid("8a1d53cd-42ce-4e23-82f6-8dca0bf3d5db"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-3.png" },
                    { new Guid("8bc01f8d-e642-4f22-98fe-958b71b14323"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-3.png" },
                    { new Guid("8bfe1486-cf32-4e32-9c71-f2ff0b8d7b5c"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-1.png" },
                    { new Guid("8cf964cc-b3b1-47c6-9873-3d8c55c2b70b"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-1.png" },
                    { new Guid("8d5d58e4-7639-4e24-b809-b1380fa2caaf"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-2.png" },
                    { new Guid("8dcf9440-5324-47f9-9b2c-048b9c553225"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-2.png" },
                    { new Guid("8e37c6aa-e0de-4090-8694-97504bc39520"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-1.png" },
                    { new Guid("8efe3b1a-f8e7-4422-b560-95616891b633"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-2.png" },
                    { new Guid("9059e43f-88e1-49d2-86f6-08101b2fdc08"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-1.png" },
                    { new Guid("910d586c-df4e-4cc9-aeef-57e3574459e6"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-1.png" },
                    { new Guid("91fafa38-e159-4cf0-954e-962f65068719"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-1.png" },
                    { new Guid("9274b685-c8bb-44e8-8c1c-36ecdf98c511"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-3.png" },
                    { new Guid("934aa0dc-7315-4d72-a1cf-3002e8629aab"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-2.png" },
                    { new Guid("94158a34-85c1-4357-af42-93c011619142"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-1.png" },
                    { new Guid("955d5cc5-3a1e-47f2-a604-8b584de30c7a"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-2.png" },
                    { new Guid("9619bd46-6630-41fc-a435-7aee4758cd60"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-3.png" },
                    { new Guid("96260d45-1ef5-4494-bad9-c324e31e247f"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-2.png" },
                    { new Guid("96fc101c-9ab3-4889-a54e-d659a0fc7f0c"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-1.png" },
                    { new Guid("975ff334-3dd2-4d78-b6ba-8db71600e4d6"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-2.png" },
                    { new Guid("9785e358-8588-4043-b7fa-4be8437ea479"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-3.png" },
                    { new Guid("97ce0c31-01b2-46eb-8e3b-4281d4cec9f7"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-2.png" },
                    { new Guid("97d08e60-c4f7-4c54-9fa9-ac79078f164a"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-3.png" },
                    { new Guid("98990e54-a584-473e-872d-679f23961cf1"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-1.png" },
                    { new Guid("9ce446ec-24ba-460d-9feb-10b12b4136b1"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-3.png" },
                    { new Guid("9d4c2d61-07a8-4841-a2c5-74b1aee02ad0"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-3.png" },
                    { new Guid("9da40c85-5497-4414-a95f-ba389e9396e2"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-2.png" },
                    { new Guid("9e77c7d4-2df3-4263-bf7b-782843377bee"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-2.png" },
                    { new Guid("9f6cdece-9384-47fd-823c-00d3fc9941c6"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-2.png" },
                    { new Guid("a0105f30-2564-4af8-aed0-25a9b2f46f71"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-1.png" },
                    { new Guid("a0b98173-8da3-4352-acb5-a7a79ad24c32"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-1.png" },
                    { new Guid("a3641cce-9f94-4b04-9a51-66bd2bed4cc5"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-1.png" },
                    { new Guid("a39fc4d1-8d49-435f-a38d-1e22e3f06560"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-2.png" },
                    { new Guid("a4644403-df7e-4577-8682-37e998d07084"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-3.png" },
                    { new Guid("a4ccdf56-18d0-4014-a677-049b38134b19"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-1.png" },
                    { new Guid("a4d54263-c8e8-47c8-9fce-bdf567f7c8ab"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-1.png" },
                    { new Guid("a4fdf067-ffaf-46b5-adc1-4bca81fde565"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-2.png" },
                    { new Guid("a5b19dbf-3525-471b-a082-296a9bc42653"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-2.png" },
                    { new Guid("a69cf449-8b15-4c54-934e-2d1a75dd9824"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-3.png" },
                    { new Guid("a7bb23b8-f353-4838-a6fe-6dc17e0a35aa"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-3.png" },
                    { new Guid("a8e7e5b6-3c44-4a74-a310-9c7e9a39d624"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-1.png" },
                    { new Guid("a97b401c-f017-4a45-8a73-5b143d7126ac"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-2.png" },
                    { new Guid("a98cd284-22dc-4a7b-b6ec-bba5bdebe80f"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-2.png" },
                    { new Guid("aa1185b7-d339-4b00-ae79-8c5f4a6a51c2"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-2.png" },
                    { new Guid("aa55fb27-9341-4de1-9c29-9ff452590bdd"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-1.png" },
                    { new Guid("ab404512-6aa9-42df-af1f-34107bb0ef30"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-2.png" },
                    { new Guid("ab4af587-3f56-4784-94b4-f501584f711c"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-1.png" },
                    { new Guid("ab6006da-33ac-4f9e-acef-3e268fa3dd50"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-3.png" },
                    { new Guid("ac0b6a46-119c-4c03-9569-062b0f2df72d"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-1.png" },
                    { new Guid("ac705880-e1d8-49de-89ce-31bb4f5104df"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-3.png" },
                    { new Guid("ac821900-68d4-44f4-9d72-2706f361eb51"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-3.png" },
                    { new Guid("ae1c0030-4a6c-4e85-aa83-682c4eb748a8"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-2.png" },
                    { new Guid("ae711aba-9633-4b49-a69e-0d75f8947e8f"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-3.png" },
                    { new Guid("aeb18d6b-9395-4a27-b5a8-d728e3d34d3e"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-2.png" },
                    { new Guid("aecaa132-3afc-47b2-b3cf-2496de690eda"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-2.png" },
                    { new Guid("b0e3a9c9-84c3-4f60-83d3-e196ccefd8bc"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-2.png" },
                    { new Guid("b103ef9a-b485-4474-8655-e34f9a56a998"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-2.png" },
                    { new Guid("b25bc3a1-33bb-47e5-a7ab-8fe8bdfabb7d"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-1.png" },
                    { new Guid("b47a4cae-5f4b-4655-bea6-65a631c3c82f"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-1.png" },
                    { new Guid("b52cb0d0-fbc1-4614-8dcf-9225dfb69f2c"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-2.png" },
                    { new Guid("b5366672-5c45-4c30-91b5-2cb5430f8c76"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-1.png" },
                    { new Guid("b80d1afd-5ead-4547-872b-9459f792ea44"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-1.png" },
                    { new Guid("b85ad187-d08f-4ef9-8a6e-25acb2e3ebde"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-1.png" },
                    { new Guid("ba80ba85-d11f-48c8-a3b9-9f61f6ba14cb"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-2.png" },
                    { new Guid("bc44094b-e2e2-4d01-a0c6-855ebc3b5d92"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-2.png" },
                    { new Guid("bcc08899-b104-4d32-876d-a5b1dc74b2d8"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-2.png" },
                    { new Guid("bcc2f18f-2891-4e62-9893-61376684028f"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-2.png" },
                    { new Guid("bce64ca7-8396-4af4-b31a-e199cc59d5f7"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-2.png" },
                    { new Guid("bdd99213-bee6-46ae-8a8a-848deb50f680"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-3.png" },
                    { new Guid("be4d922c-b63e-4c5f-8dfe-789b59cbf8cd"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-3.png" },
                    { new Guid("c0b5b27d-4768-4189-a6e7-8779ecf21987"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-1.png" },
                    { new Guid("c138a237-e032-4c66-9e34-7b1da3a3b924"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-1.png" },
                    { new Guid("c28dd351-1602-487a-a989-85090bac4dd2"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-1.png" },
                    { new Guid("c2f6be3b-8427-4c23-a1a0-b730c1781180"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-2.png" },
                    { new Guid("c2f93dd8-7cef-4cb4-afc4-ba13a5dde9e5"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-3.png" },
                    { new Guid("c41c3baf-c245-4338-93da-c83f5a9cd533"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-1.png" },
                    { new Guid("c4bf8054-1e98-4730-910e-4887bc67b121"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-2.png" },
                    { new Guid("c5772fd9-0d22-46ff-a5b2-133e460a9cff"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-2.png" },
                    { new Guid("c59c9aae-ac14-4cbb-8151-29a49551e9eb"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-2.png" },
                    { new Guid("c6897dcf-b505-4da2-ba0b-7ccf70c1734b"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-1.png" },
                    { new Guid("c691a035-aa62-4bd9-8d8b-8adde2a7b625"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-1.png" },
                    { new Guid("c8837a95-361f-46b5-880d-baa362734226"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-3.png" },
                    { new Guid("c94b6966-5c12-440c-b3ab-2fde1ce081b8"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-1.png" },
                    { new Guid("cc804f69-124c-46d7-aeda-964eb304bb20"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-1.png" },
                    { new Guid("ce254040-7647-4467-90c0-50aa6c556dd0"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-3.png" },
                    { new Guid("cff6dbbf-f887-40dc-b9e2-11190abb5f79"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-2.png" },
                    { new Guid("d051a401-49c0-49a4-9ca5-5e5a31759751"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-3.png" },
                    { new Guid("d0c879b8-ce5c-4dee-9142-14b823d71bfe"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-2.png" },
                    { new Guid("d120c7d0-6dd8-4111-9e26-aa3b1f3c0a05"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-2.png" },
                    { new Guid("d2033750-132a-458e-a694-b31c40d1834a"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-2.png" },
                    { new Guid("d22722d0-f438-41b4-ba9b-c40cf5909f15"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-3.png" },
                    { new Guid("d338579f-e56e-40f8-8117-90ed632f0a77"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-3.png" },
                    { new Guid("d41bd53b-596b-44bd-972a-c00268250e47"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-2.png" },
                    { new Guid("d47be455-49aa-48bc-acba-18f33a47e985"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-1.png" },
                    { new Guid("d4b739ef-3270-4d34-b939-df5d0383009e"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-1.png" },
                    { new Guid("d4dfb595-c6b1-4da1-bcbb-6fa36254a0dd"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-1.png" },
                    { new Guid("d5edca5c-56a6-4894-b84b-45302de97e4c"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-2.png" },
                    { new Guid("d61a930e-3e86-4a66-92b3-25ed3bfd2c4e"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-3.png" },
                    { new Guid("d664166f-09ea-4a01-ae4b-a300f788d222"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-1.png" },
                    { new Guid("d7cf3250-728b-4323-b7a8-0882d15fd46d"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-1.png" },
                    { new Guid("d8ea8cad-7ffc-462e-89d3-0133b4ec163b"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-2.png" },
                    { new Guid("d9adbdd4-4449-45f6-8ca2-9d6105da1fa0"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-3.png" },
                    { new Guid("d9f61c6d-9346-4862-8ad9-7b9aec1a63dd"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-2.png" },
                    { new Guid("dd2ef277-ef7a-4af9-8566-54eb392deee0"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-1.png" },
                    { new Guid("ddc360b3-507e-480b-b6a8-2fd70b14a1e5"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-1.png" },
                    { new Guid("df76eb0a-0606-41c3-818d-b8553bbb0dbb"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-1.png" },
                    { new Guid("e0c030b8-0a50-4ab7-9a00-1c88558046a3"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-1.png" },
                    { new Guid("e2d80dfb-b79e-4f2b-a407-53e8f295d402"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-1.png" },
                    { new Guid("e3bf0ecd-367b-48fe-a784-ac8696b153fa"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-2.png" },
                    { new Guid("e49d92ea-bc96-4cdf-a3f4-4fce74c3eaf7"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-3.png" },
                    { new Guid("e53c7c57-83fa-46c5-8670-f6918038c7a1"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-2.png" },
                    { new Guid("e5fcd77b-fc75-4714-b02f-2b5880376f00"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-3.png" },
                    { new Guid("e63c0486-6325-42d7-8555-effe00c32a6f"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-3.png" },
                    { new Guid("e6b88504-b992-4fe2-8a4a-94abaa4bb350"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-2.png" },
                    { new Guid("e740b2fc-ac66-4072-b4a3-6ed50621e407"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-1.png" },
                    { new Guid("e8048c32-b0ea-48f0-ac4a-05aad45e5c8a"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-3.png" },
                    { new Guid("e81b34fa-61fc-487f-9db9-643f64f82ad1"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-1.png" },
                    { new Guid("e86f0b84-a230-44ee-9f3a-34fc078bfe6f"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-3.png" },
                    { new Guid("e91234ed-6a23-49d8-b245-861b6ac39ce1"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-3.png" },
                    { new Guid("ebfc7797-7e11-4d77-8985-1217005021c7"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-3.png" },
                    { new Guid("ef0abc68-0a37-448b-8c1f-4dd8ea7d7af9"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-2.png" },
                    { new Guid("f12dae15-e29e-4e4f-8653-48903fd91c32"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("f15eccaa-dde0-4853-bf39-0f120c6d77e1"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-2.png" },
                    { new Guid("f29e5e74-2081-470a-a2e0-bf2a8d5ebe69"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-1.png" },
                    { new Guid("f34287dc-28c5-42d8-bbee-33d16e8eb6cb"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-2.png" },
                    { new Guid("f39af428-e640-49ad-ade6-f268b885009e"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-2.png" },
                    { new Guid("f5b94346-1956-480a-919c-2f25c11ad9d2"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-2.png" },
                    { new Guid("f6e4e999-9a4a-4308-ad55-5b76252d88da"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-3.png" },
                    { new Guid("f7fccbc5-1d22-4d44-8915-2a59109e1d5c"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-2.png" },
                    { new Guid("f8001aaa-9700-4ea2-9355-dd49f11703be"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-2.png" },
                    { new Guid("f86b3e41-a058-412e-ae84-82828fbde329"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-2.png" },
                    { new Guid("f891354d-09ec-4b2c-ad09-005c95567c08"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-3.png" },
                    { new Guid("f8b68aea-bf2c-4f72-80f6-5a194b79bfb3"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-3.png" },
                    { new Guid("f9024a94-ae92-4ad2-af74-c3a2d0506994"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-2.png" },
                    { new Guid("fa48f03c-c23b-463a-9efc-b9a5d71faf57"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-2.png" },
                    { new Guid("fa4cf5d4-cb0c-4095-aca0-d0df31e731b1"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-2.png" },
                    { new Guid("fac0709f-9bcf-4c50-9ea8-2102c11cb3ba"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-3.png" },
                    { new Guid("fd3d2d80-874d-473e-aa39-c00efb7ce28b"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-1.png" },
                    { new Guid("fdf1b4df-ef1e-4bdf-bedf-cc89d8c9a475"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-1.png" },
                    { new Guid("fdf31dfb-a20b-4894-9025-99e117164e6d"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-3.png" },
                    { new Guid("feca095d-a306-4367-9e75-4e46f74b4858"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-3.png" },
                    { new Guid("ff536562-d7a1-4084-b9e7-4d89104d2aa2"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-1.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_CustomerBasketId",
                table: "BasketItem",
                column: "CustomerBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureUrls_ProductId",
                table: "PictureUrls",
                column: "ProductId");

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
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PictureUrls");

            migrationBuilder.DropTable(
                name: "CustomerBaskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
