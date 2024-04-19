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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
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
                    { new Guid("00acf86b-f776-476c-8fd7-b9b0aa92d926"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-2.png" },
                    { new Guid("02b1814d-601a-43ed-afbd-301315d524b4"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-1.png" },
                    { new Guid("02e160ba-8bb2-4d92-9416-eab87b6a28c3"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-3.png" },
                    { new Guid("0340d4af-e2ff-4266-b5e2-31f23368c25c"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-1.png" },
                    { new Guid("05e0ea7a-4a1d-4605-95ba-f38f1db0ee21"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-3.png" },
                    { new Guid("05f83e21-35ac-47c6-9243-1195bd95d501"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-3.png" },
                    { new Guid("075fb70e-e1e7-4e80-b1b6-b4c4aa26b598"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-1.png" },
                    { new Guid("077c57ed-f33d-4a30-bc1f-01238371dbd0"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-3.png" },
                    { new Guid("07d86e42-ae91-45a0-8dc7-845a99fecb25"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-1.png" },
                    { new Guid("086614c3-9660-4e73-9a40-c7342972424f"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-1.png" },
                    { new Guid("08c60b6a-40f1-4497-be4f-f3de1480c3ce"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-3.png" },
                    { new Guid("09e2b5f4-c657-42c3-af56-989160fc249f"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-1.png" },
                    { new Guid("0c3d81ec-c192-4613-b5cb-490a672575fe"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-3.png" },
                    { new Guid("0d7d4fcc-53c3-4317-8309-243267dfea43"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-1.png" },
                    { new Guid("0da41a69-3c48-4078-a45a-76d766fa23c3"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-3.png" },
                    { new Guid("0df0a059-b9b2-4f81-b00f-f82e1a302347"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-2.png" },
                    { new Guid("0ee13b77-4ea5-4ffe-aae8-b523c41d8a99"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-1.png" },
                    { new Guid("0f4e19ec-aef3-40d0-85ea-824728bc73e7"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-1.png" },
                    { new Guid("108d2d45-1574-4475-a7fb-702ea93eac80"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-2.png" },
                    { new Guid("11504603-58bb-42d5-bd67-13882c0603f3"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-2.png" },
                    { new Guid("1165ef94-0549-48af-8fde-88b86b2b2367"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-3.png" },
                    { new Guid("13fe4bf8-1d6b-4f1c-955e-63fdada0625e"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-1.png" },
                    { new Guid("14358043-a170-45b7-9c0f-bbac281fe2f6"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-3.png" },
                    { new Guid("14c7ed83-f20b-42d6-9c99-c3a6284d2442"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-2.png" },
                    { new Guid("17765c6d-459c-4dd5-accb-6a4f5e178430"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-3.png" },
                    { new Guid("1986364b-29e4-40b7-9688-0f69f8334951"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-1.png" },
                    { new Guid("1a004fa0-b9f7-4ad5-b467-d4c49b48c18b"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-2.png" },
                    { new Guid("1a210e5e-7f9e-4f26-bc03-bf01d9703ba7"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-3.png" },
                    { new Guid("1a6681b7-6157-414e-9c88-685cfa1c3aae"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-1.png" },
                    { new Guid("1e5ea139-aedb-4119-ad94-e54667ab131d"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("1e9d2c5d-7f82-436f-98ab-4faf991c16cf"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-1.png" },
                    { new Guid("1ec23322-0783-4c73-921d-f7156257ea09"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-1.png" },
                    { new Guid("1eedc752-2dc6-466d-bb8b-70cd10daf555"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-1.png" },
                    { new Guid("1f91e1ed-9994-462f-844c-adddd971a2d9"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-1.png" },
                    { new Guid("1fcbaf5f-5de2-4aa4-a960-3b277ce16297"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-1.png" },
                    { new Guid("213eae51-349d-49f9-8500-38a85acd9305"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-1.png" },
                    { new Guid("22dd97d1-a395-49b3-bd0e-e1c88fd8cf84"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-2.png" },
                    { new Guid("23bd4694-d260-499e-bdca-24d8b5ac1900"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-1.png" },
                    { new Guid("24ec070f-06c4-4ca3-b2a7-290a7501b2c1"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-2.png" },
                    { new Guid("256381af-9336-4bb7-ab6d-f553da21f730"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-3.png" },
                    { new Guid("25854851-6ee9-45ee-ba52-597c8cb32864"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-3.png" },
                    { new Guid("270b4063-dd5b-4370-8d2a-af4fc9351e56"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-3.png" },
                    { new Guid("2802c8dd-3b91-4b6c-8b8d-6fda891e3b64"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-1.png" },
                    { new Guid("2b702406-363a-40e8-b8a8-551a16c49f8d"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-1.png" },
                    { new Guid("2baafaa2-804c-400e-a4c1-14d898d9d881"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-3.png" },
                    { new Guid("2be70997-c788-4b8b-aa6a-0b1a479180b7"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-3.png" },
                    { new Guid("2bf42132-0d83-4327-9230-7e978ab9f95e"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-1.png" },
                    { new Guid("2e49ea56-680f-4266-82db-40217220e2ce"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-1.png" },
                    { new Guid("2f08b72d-2396-4da6-a780-2e8910ddf4cc"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-1.png" },
                    { new Guid("2f2a774a-a9b1-49f6-aad4-a18fadf70517"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-3.png" },
                    { new Guid("304ef200-a4c7-4029-8fb0-e7a4f60a5dd7"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-3.png" },
                    { new Guid("31220bcb-0ee4-4ef9-a5af-2ae96838cdb3"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-2.png" },
                    { new Guid("32424929-5f82-422d-8f2c-57bf6eb1a25b"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-2.png" },
                    { new Guid("32d6485f-e825-4bb5-89e5-3523404d31ee"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-1.png" },
                    { new Guid("3826e434-3be9-4694-b124-c36f53c05074"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-2.png" },
                    { new Guid("383e5bab-fb39-4cad-8694-9aae389da463"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-2.png" },
                    { new Guid("38455b1d-2e59-44ca-b733-864abb6d80d4"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-1.png" },
                    { new Guid("392ac7e2-f112-4e58-b5d2-e08a2039ddcc"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-3.png" },
                    { new Guid("3aaf5265-872b-475d-8928-009b83f77b84"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-2.png" },
                    { new Guid("3b5a352a-8723-48cb-9669-9c6559080781"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-2.png" },
                    { new Guid("3b7f468d-2de6-4b69-b08c-22afd00ba2da"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-2.png" },
                    { new Guid("3b89e939-1f86-4241-8f3c-53b1a9dd1635"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-1.png" },
                    { new Guid("3bc03e77-d3c3-42d8-8603-1f155165f68f"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-2.png" },
                    { new Guid("3e84c075-ac31-4585-b0bd-3222b3d3b13a"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-3.png" },
                    { new Guid("3eaa74c8-477a-4ed5-9399-c56913401d44"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-1.png" },
                    { new Guid("3fd270b5-6f14-4d5f-9e68-e6ea8c1da3a2"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-1.png" },
                    { new Guid("4012a444-b555-464e-b0ff-6862f9687aa0"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-3.png" },
                    { new Guid("40b3b29b-053c-427d-a2e6-9217f27898be"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-2.png" },
                    { new Guid("4196c3ca-024c-46aa-bc42-534e98e9c43f"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-3.png" },
                    { new Guid("422f6ad8-ac4b-4011-8f5e-9528d628d833"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-3.png" },
                    { new Guid("42ad08a6-837a-49ef-8a73-bff0ba12214d"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-2.png" },
                    { new Guid("42e174fc-a310-41b4-a65b-e7a6e6b38703"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-1.png" },
                    { new Guid("43025bd3-72d3-4ea0-b2d0-0ad7fca555f2"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-2.png" },
                    { new Guid("459bfc9b-e14b-4571-bc4c-a291fbad88bf"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-2.png" },
                    { new Guid("46b7a64f-d737-4ce5-8b07-f9f72ee1257e"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-3.png" },
                    { new Guid("489514c1-f43e-4432-9af0-46bcf5c6d0d0"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-3.png" },
                    { new Guid("48d7a28b-cf0e-4724-8fcf-56656f9b703c"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-3.png" },
                    { new Guid("4a247c62-0fd3-40a0-90de-bd0be4f0b40a"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-2.png" },
                    { new Guid("4ab47308-8f3b-455d-977e-b758c5d94fb9"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("4ad45100-36e1-4bfd-ac51-bc6ea00bcdbf"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-1.png" },
                    { new Guid("4aef7308-9d2a-435e-a340-eedf1fd78553"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-2.png" },
                    { new Guid("4b20dc72-5fa8-45eb-bd4d-4061cd207f85"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-2.png" },
                    { new Guid("4bf58eb1-31d9-45b2-81eb-d57059bdc251"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-2.png" },
                    { new Guid("4c012cc0-36f3-4338-8399-7a3f85fbe551"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-3.png" },
                    { new Guid("4cacd926-f95c-4d95-a42c-3f3edc4de057"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-2.png" },
                    { new Guid("50c03b80-e146-47a5-9c68-f263f7666717"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-1.png" },
                    { new Guid("50e98578-2112-4115-a594-98797c262b51"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-3.png" },
                    { new Guid("51afebaa-e730-44d1-95f0-e0f9d809f69f"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-2.png" },
                    { new Guid("51c43a43-9a07-4aab-b03b-b7f7f78250cd"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-3.png" },
                    { new Guid("523e086c-c633-421b-88ef-bc92101e308d"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-2.png" },
                    { new Guid("52666eba-8ba4-468e-94b7-bc3487328b74"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-2.png" },
                    { new Guid("52b7d262-4b82-4992-af68-24aa6470e64f"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-1.png" },
                    { new Guid("52bf63c3-25f9-4b65-8ba0-3c98713c8379"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-2.png" },
                    { new Guid("5309e309-6dda-49f8-9ed6-e499ec26c911"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-1.png" },
                    { new Guid("53c8670f-1826-44a5-b014-b7c0d68f4b9f"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-3.png" },
                    { new Guid("54ad613d-8c17-4634-9323-bba3a6b5ca31"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-1.png" },
                    { new Guid("56b6f6d0-58c9-4883-89f3-c7f642f23ac6"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-2.png" },
                    { new Guid("57a663ca-8786-460e-8534-6e9adf66ccdd"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-2.png" },
                    { new Guid("581de875-8ff0-4425-9609-5e14eac002e2"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-3.png" },
                    { new Guid("5862ce65-8227-4c6f-b687-0b0f824d5d7c"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-2.png" },
                    { new Guid("5945f7e2-febc-4514-b568-4b3ee17bff96"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-3.png" },
                    { new Guid("5a2a381b-c915-48db-8aae-616473f01a30"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-1.png" },
                    { new Guid("5a3e9e4c-2c24-4af4-ad8e-0b30e64328cc"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-1.png" },
                    { new Guid("5a8c88f6-f528-4839-aff6-9dde39095621"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-1.png" },
                    { new Guid("5c1b0629-a109-4c42-b63e-800b6b29c6ee"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-2.png" },
                    { new Guid("5de8e3a9-6eb6-4a9e-a824-03f2c9f46296"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-3.png" },
                    { new Guid("5e58f381-4316-4565-aa07-325c905307cd"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-3.png" },
                    { new Guid("5e958adc-a864-4514-a8c3-a2622ca59898"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-1.png" },
                    { new Guid("5ea68b5d-999d-44ec-966a-829bd2be495a"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-3.png" },
                    { new Guid("60af2a7e-98eb-4f18-b8e1-ad1802364584"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-1.png" },
                    { new Guid("6109e32b-11a2-4bd2-8f20-0cce2731aaef"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-1.png" },
                    { new Guid("6159329b-a055-41a9-876f-efb3a01de7b0"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-1.png" },
                    { new Guid("618bb56a-1ae8-4bc0-9b6a-7365c3ec47b0"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-2.png" },
                    { new Guid("61ca651c-ecfe-45ca-aa02-acb4c4828042"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-1.png" },
                    { new Guid("62961f23-5027-406e-acb1-7ffce501a70b"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-2.png" },
                    { new Guid("63005a17-ff9a-41c9-b85e-ee7c5ba40127"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-1.png" },
                    { new Guid("63375c0d-a626-4829-ab4e-79ed82953061"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-2.png" },
                    { new Guid("6353e833-0097-4e8b-8dea-db2de36d02bb"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-3.png" },
                    { new Guid("64fd28e2-4e7c-4c0c-83e1-da205ff5dbd2"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-1.png" },
                    { new Guid("66d94122-50b8-4de2-ad8c-6d0c828c5f67"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-1.png" },
                    { new Guid("67714dda-cb20-49bd-97b8-5718fa2f01dd"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-3.png" },
                    { new Guid("67a5ca1f-f2c5-46cf-a6de-db29bd98be0f"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-1.png" },
                    { new Guid("68389031-e1f9-480b-8f3c-da83bacbb409"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-1.png" },
                    { new Guid("698397ed-d036-46c9-8bbf-ee9bab8bc145"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-1.png" },
                    { new Guid("6a805351-ecaf-47c5-baf8-7088bf7f1dde"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-1.png" },
                    { new Guid("6abcb9b4-5388-4fdb-a8b6-2859cb1f13c4"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-3.png" },
                    { new Guid("6ba81391-722a-4c26-a964-5078c151eed7"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-1.png" },
                    { new Guid("6bb18f7e-f4d4-4180-b459-0830dc3e721e"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-2.png" },
                    { new Guid("6c6060b5-ad0e-4f95-abc1-7f391ea2640c"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-1.png" },
                    { new Guid("70d8e611-f2ae-49e2-a7b5-ca8a03ebfadf"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-1.png" },
                    { new Guid("71e2ddca-a2d2-473c-bf85-90124c3331a1"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-3.png" },
                    { new Guid("7260df1e-9aa4-412d-b84b-a5867cd2a6c4"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-1.png" },
                    { new Guid("72681d75-94ad-44d7-9483-b14550b3cfbe"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-2.png" },
                    { new Guid("72f71065-e484-4ea3-86d7-b6dd217204de"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-3.png" },
                    { new Guid("733c76f8-ebdb-4ceb-a8f5-cc62e3b94e76"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-2.png" },
                    { new Guid("7487dc0b-6089-43cc-afa2-c0184bc133cf"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-3.png" },
                    { new Guid("75b4819a-c71a-42f9-bad9-1e866b6856c4"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-2.png" },
                    { new Guid("7703a9a0-b4cc-4554-95d6-1ded5beba547"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-2.png" },
                    { new Guid("77a6ca9d-9685-4e99-9c0c-63115b9d3ff1"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-3.png" },
                    { new Guid("798e77d7-5f10-4068-9e85-e814a6a06e44"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-1.png" },
                    { new Guid("7aada0a2-9fa3-4d59-9199-0e2d7b17e704"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-3.png" },
                    { new Guid("7b6fb57b-cb28-4003-befa-fc6b7fe4fed8"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-3.png" },
                    { new Guid("7c731c27-2d23-4d5f-814e-7f7606a714d5"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-2.png" },
                    { new Guid("7d653fa9-ae46-4811-a597-64b0d0ae4ffc"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-3.png" },
                    { new Guid("7df92921-1fd8-464b-8469-91ee0ecc9f3b"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-1.png" },
                    { new Guid("7f20a356-7610-4022-8474-0a48c852765d"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-1.png" },
                    { new Guid("80260e50-58b6-43ee-9975-0a88dd5c14e5"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-3.png" },
                    { new Guid("81760c8b-bd28-483e-a63e-875e01c54db7"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-1.png" },
                    { new Guid("81de0031-52cc-43e3-a073-74f1a214b6b8"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-1.png" },
                    { new Guid("81eee138-cd06-4280-834c-111b24609e59"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-1.png" },
                    { new Guid("82330d82-140c-4e97-951e-b57ddab1ca25"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-1.png" },
                    { new Guid("82fa996c-9b5c-4a82-a229-049e2604448a"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-2.png" },
                    { new Guid("8371a616-2ae1-4646-b479-7f33d0680389"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-1.png" },
                    { new Guid("8585228d-01f5-4171-8f9a-152d4e9942eb"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-2.png" },
                    { new Guid("86c0736b-d4ed-41b4-9bfb-24d67a6909a1"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-2.png" },
                    { new Guid("88ec1ed7-9a51-46da-8775-690a982b42b4"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-2.png" },
                    { new Guid("89221196-4c06-460d-ad34-db65e4f241fe"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-1.png" },
                    { new Guid("8940db74-98c2-4fd8-9b8a-ab796157ef70"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-3.png" },
                    { new Guid("89c5b06e-32f8-4539-b491-6e36af4fa096"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-3.png" },
                    { new Guid("8c140a77-2685-48b5-ba21-66efbd433b01"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-1.png" },
                    { new Guid("8c41ccf4-a6ae-4be7-abd1-62ac2ca65f8a"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-3.png" },
                    { new Guid("8f291bee-bea6-4b74-ab21-425c1d9da25a"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-2.png" },
                    { new Guid("8f2a5501-3736-4d5d-9d4d-ff86e558705a"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-1.png" },
                    { new Guid("90799f8b-06a5-4440-8b1d-d7c8459bbcdd"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-2.png" },
                    { new Guid("9160a5de-bf64-4ef5-9fea-7361406c8398"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-2.png" },
                    { new Guid("9197313b-b09e-41f9-91f8-5ca2a3d0fb30"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-3.png" },
                    { new Guid("923c06c4-768a-48a1-8e23-606b86b86a9b"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-2.png" },
                    { new Guid("92ce6da3-432b-4d10-86ca-b34ef64549e2"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-2.png" },
                    { new Guid("93b713e0-9c2b-415b-84ab-cc63c83d36bf"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-3.png" },
                    { new Guid("93dc2621-5507-43b0-960d-9740339df1cc"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-2.png" },
                    { new Guid("95747a93-ea47-48e0-b4db-233f517135d4"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-3.png" },
                    { new Guid("966ead6e-080e-46b5-9e56-0369986f575c"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-3.png" },
                    { new Guid("967ffd9b-c00f-4f7c-b458-4049029940c5"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-2.png" },
                    { new Guid("96fae010-8c03-45d6-8b7c-4ef0821d36f4"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-3.png" },
                    { new Guid("97a61e40-d580-43f1-9ea1-c7d996ac6889"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-2.png" },
                    { new Guid("97d6a879-2c35-4ddd-bc34-8bb37ed00de3"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-1.png" },
                    { new Guid("99ec474d-3935-4515-ab44-5bd9dafd8056"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-1.png" },
                    { new Guid("9a0ed0a8-2986-4e7d-a315-9d92824a4937"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-3.png" },
                    { new Guid("9a8ac24f-f9d4-483b-a8c8-0c68487d5146"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-1.png" },
                    { new Guid("9aa15711-ee22-452e-8cb1-26cb6f5a3960"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-2.png" },
                    { new Guid("9b4151ad-7527-4836-ace4-398fdce6ead2"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-3.png" },
                    { new Guid("9b459ca0-e6fc-4cfc-94df-b7e214b2ee76"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-3.png" },
                    { new Guid("9bf8f687-7abb-418e-b089-fb286587c6cf"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-1.png" },
                    { new Guid("9df36abb-7f41-40ac-a7a3-770fbbfc9314"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-1.png" },
                    { new Guid("a00e5aef-8031-4041-86c7-eb6289323f97"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-3.png" },
                    { new Guid("a0286e88-dcc1-4794-8ff9-896a05347d03"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-1.png" },
                    { new Guid("a1b335da-2607-4348-af47-1ebfcbfc71cc"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-1.png" },
                    { new Guid("a2915549-c9d0-42b1-bc19-e362128f6499"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-2.png" },
                    { new Guid("a31c0a71-f198-441c-8f92-8153286e689b"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-3.png" },
                    { new Guid("a335f7cb-0578-429e-8286-9048464e53dc"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-3.png" },
                    { new Guid("a3b38a0c-98b2-4b06-b137-4571ae38904e"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-1.png" },
                    { new Guid("a53be0bf-b3b8-4eba-ace9-9875f978fc47"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-2.png" },
                    { new Guid("a56e1185-305a-45d7-9e0f-32173abfb363"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-3.png" },
                    { new Guid("a61a31b5-16fd-49bc-9729-1533602bec7d"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-2.png" },
                    { new Guid("a6660338-b0be-44e3-9364-58048694be8c"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-2.png" },
                    { new Guid("a7470ef9-c620-46e2-9325-683a4566cec1"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-1.png" },
                    { new Guid("a810e9e7-59be-4c9f-ba1e-48c13dc58196"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-1.png" },
                    { new Guid("a945f858-eb90-435e-8245-035bdcee7edf"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-1.png" },
                    { new Guid("a94adff3-8fe7-4430-8657-3a104ac98b98"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-2.png" },
                    { new Guid("a95f3156-4131-458c-8150-9f22d3f0e8e3"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-1.png" },
                    { new Guid("a9de1715-5587-487b-9fa4-92f228b1e910"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-2.png" },
                    { new Guid("ab3d0473-7a02-4b33-90fc-fdce4635231b"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-1.png" },
                    { new Guid("ac6e1737-c906-46e6-ba16-7e64ddd793d5"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-2.png" },
                    { new Guid("acb79817-0cb9-4f70-b142-696665199d20"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-3.png" },
                    { new Guid("ae5edeea-944f-48f3-b20c-c2a48372ab4d"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-2.png" },
                    { new Guid("ae903490-01d1-4171-aabd-4999fef38610"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-2.png" },
                    { new Guid("afbd6c20-43d3-4942-bee6-6737dfe5969a"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-2.png" },
                    { new Guid("b03cf932-bcf4-4a7a-936f-df936f431348"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-3.png" },
                    { new Guid("b058a021-281a-42f1-9380-b49e0ca6918f"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-3.png" },
                    { new Guid("b0e69a42-ab39-4ca1-b573-9baaf00b8548"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-2.png" },
                    { new Guid("b14771c1-6cb6-4f09-a85d-dc4fef920f22"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-3.png" },
                    { new Guid("b2032cb7-7c1c-4424-b6e1-0546223543c1"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-3.png" },
                    { new Guid("b28f3c95-edb6-4cd1-a331-65d59cf2fddc"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-2.png" },
                    { new Guid("b3ba759b-6082-4363-b4de-efa8fc7fc68a"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-2.png" },
                    { new Guid("b418146b-08c3-4dfa-a53d-82561f21c87e"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-2.png" },
                    { new Guid("b41a653a-ab36-4d1f-aa91-99d27c6ca7e4"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-1.png" },
                    { new Guid("b46560b5-119f-4d6f-a3af-7cef2dea6b63"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-1.png" },
                    { new Guid("b5b2d20a-26b7-4692-98b7-8a37452aba70"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-1.png" },
                    { new Guid("b641b623-b331-4acc-bb9b-700d18310f76"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-1.png" },
                    { new Guid("b66cadbd-1c49-425b-8140-d266e8edd95b"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-2.png" },
                    { new Guid("b8d26326-f02e-4159-b8d9-c0c2be8b627c"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-1.png" },
                    { new Guid("b9a708cf-955c-4ec5-a37f-96f6e6f125c3"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-2.png" },
                    { new Guid("b9ebbf80-d200-41fc-bbb0-d2f15a7e5115"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-3.png" },
                    { new Guid("baec66d1-16fe-4642-b635-4f29935df63b"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-3.png" },
                    { new Guid("bb004dd8-45d7-4ea3-850d-eea3b16f4f13"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-1.png" },
                    { new Guid("bb8d50a9-a721-4d09-8149-d24bab85d64b"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-1.png" },
                    { new Guid("bbc5b17f-8cdd-4431-bd3f-e4f16d074738"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-2.png" },
                    { new Guid("bd42abd7-7c3e-4bf2-90ad-4c9c4e4c8365"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-1.png" },
                    { new Guid("be9d8e9e-99cb-4ba4-b8ea-802363ec5dd3"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-1.png" },
                    { new Guid("c12aa130-54f9-4081-bf46-25007cd0841d"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-1.png" },
                    { new Guid("c2680545-b0f7-4d4b-bfea-e029946a1bd5"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-3.png" },
                    { new Guid("c2ab6242-422d-43b2-8f56-4b71a2e963df"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-2.png" },
                    { new Guid("c2c5f8cf-2e11-4957-90f2-88873674ae61"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-3.png" },
                    { new Guid("c3cad39d-cf8a-41be-aacc-ce2a1e50450e"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-3.png" },
                    { new Guid("c3d0230c-f61b-4447-ac6f-d833d0cc96cc"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-1.png" },
                    { new Guid("c65e13ce-4ca3-462a-8e11-effb207e997f"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-3.png" },
                    { new Guid("c7ded9a1-0c2d-4363-a271-b9244cb5a9c4"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-2.png" },
                    { new Guid("c8287273-5a88-4bb1-8d7c-679ce19a493c"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-3.png" },
                    { new Guid("c9cebad3-1029-44b7-9d8f-7aac71bbbe3e"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-2.png" },
                    { new Guid("caf76b8b-b3cf-4c0a-8f54-01dbf1c4dc4a"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-1.png" },
                    { new Guid("cb593c4f-3e21-41d9-954f-5985c910e979"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-1.png" },
                    { new Guid("cd8b7d48-6d3b-4c2d-88ec-41cbf3bdf527"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-3.png" },
                    { new Guid("cf238de4-0b63-41eb-8d35-9d5de936c154"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-1.png" },
                    { new Guid("cf28e0e7-dbc1-4321-995f-e94b8f5eb57b"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-1.png" },
                    { new Guid("cf515343-4b37-4e09-a2c2-4ebb9c651eb3"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-1.png" },
                    { new Guid("cfc934fb-7008-4ff2-8cd2-79ff51c42332"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-2.png" },
                    { new Guid("d000d6f4-b43f-43fb-bfea-aa31fdfb260b"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-1.png" },
                    { new Guid("d0167218-45b9-41f1-8c57-7b3cc7282c56"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-2.png" },
                    { new Guid("d2e7bbfe-248a-4955-84de-fd495d8409a1"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-2.png" },
                    { new Guid("d31b7823-5273-4b83-be3f-252fed66ffc2"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-3.png" },
                    { new Guid("d4617ccc-9387-47f2-8aa1-9920f52b289f"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-2.png" },
                    { new Guid("d4dacd65-ba69-49c0-8e40-10324e96a56e"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-3.png" },
                    { new Guid("d4f46b38-853c-4779-8e41-c700a4373d3b"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-3.png" },
                    { new Guid("d52beb3d-a102-4a02-8847-7784349548e4"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-2.png" },
                    { new Guid("d550ed8b-256c-41a2-a889-68f75492d4b8"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-2.png" },
                    { new Guid("d6291aee-02cd-4ec1-ae6d-444a69ff977b"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-3.png" },
                    { new Guid("d8933a16-06be-4d47-b800-056a42791643"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-3.png" },
                    { new Guid("d950ab4a-62b5-4485-bf0d-0e6a6a3dc681"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-2.png" },
                    { new Guid("da45b270-5804-40bc-bf18-7416efbb4fba"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-1.png" },
                    { new Guid("db9156e9-5b3f-4460-a161-685feef8e119"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-3.png" },
                    { new Guid("dbd8ecd3-619b-41f9-a63e-8b7dc2f14181"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-3.png" },
                    { new Guid("dcb7efff-a0fe-44f5-9cee-bbd05c506746"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-2.png" },
                    { new Guid("dcb85ba6-1737-4857-b72b-af95a50de6cc"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-2.png" },
                    { new Guid("ddc370a4-f4d1-4dda-9859-e4dbc1f0c7a8"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-2.png" },
                    { new Guid("e1071f90-fb7e-4929-b6d1-ea940da44bf7"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-2.png" },
                    { new Guid("e16e4909-a552-40af-a435-2ab6a90e6615"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-3.png" },
                    { new Guid("e3320025-f2a9-4941-8483-30b59c48cd0b"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-2.png" },
                    { new Guid("e3ec2735-ba25-488a-b15d-45857e14d3c6"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-2.png" },
                    { new Guid("e50b5717-0eb6-42de-a5ac-0208fc4473eb"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-2.png" },
                    { new Guid("e5aca766-6137-485d-aa79-b04797082aa2"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-2.png" },
                    { new Guid("e60fc259-44a7-4198-b0fb-c8e241e6c36a"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-3.png" },
                    { new Guid("e72936b5-2cae-4d91-88fd-bf3861af279d"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-1.png" },
                    { new Guid("e7613755-ccf5-4cd5-9cfa-eacfb4a1243d"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-2.png" },
                    { new Guid("e7b931b3-9347-40ae-8298-e4c85f7c0b2e"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-1.png" },
                    { new Guid("e8e90a86-2c89-4441-ad58-453be2951e92"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-2.png" },
                    { new Guid("e9ad42ce-130f-4f6a-baaf-51625ada86d8"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-2.png" },
                    { new Guid("eaa2d23c-17b3-45b3-aab5-df304758d602"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-2.png" },
                    { new Guid("ebc30c56-2683-4251-a3de-47c18947a710"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-2.png" },
                    { new Guid("ebf1e9ef-c4e5-4c29-9a31-3265f1f1a862"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-3.png" },
                    { new Guid("ecb92377-4a20-4b56-9146-4d790a1623cd"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-3.png" },
                    { new Guid("ecf586ab-6e1b-4bc0-bc8e-53bef0da4031"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-3.png" },
                    { new Guid("edda19f7-0b2b-4c08-9bce-cb8009c16403"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-3.png" },
                    { new Guid("ee078ec9-b0d4-4ff6-a69a-10ff36a31ba7"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-2.png" },
                    { new Guid("eeda2b76-02b2-4a54-a076-3d573edf8dae"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-1.png" },
                    { new Guid("ef1abfaa-739b-45a8-a1fe-2e08cf105110"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-3.png" },
                    { new Guid("effbb173-4d0b-40c1-be5a-7619dd6cbf37"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-1.png" },
                    { new Guid("f058e400-17ce-4d3a-8c3c-a745d9b342b4"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-3.png" },
                    { new Guid("f0850ac4-c01a-496a-b665-0ef88c9dec80"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-1.png" },
                    { new Guid("f1a1c580-c071-4d3b-b657-3beba05cbcab"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-1.png" },
                    { new Guid("f2508245-d309-494b-a819-662628a8d737"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-2.png" },
                    { new Guid("f309e587-0401-409e-be23-57a230531c23"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-2.png" },
                    { new Guid("f5e7eb17-bd99-4b01-b636-6637d02982ce"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-2.png" },
                    { new Guid("f6dca5f9-4292-48ab-82b1-c22efee8bb2c"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-2.png" },
                    { new Guid("f71d3a30-a6f0-42dc-829c-a02ce992b304"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-3.png" },
                    { new Guid("f73f3c45-43e6-4f83-9cfc-24b4a12e1bbe"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-3.png" },
                    { new Guid("f79b7030-c7d3-4d82-a74f-c774b3844e34"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-3.png" },
                    { new Guid("f7ca5c9e-3062-4e90-aec7-08de73470cd7"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-3.png" },
                    { new Guid("f7dced7e-e845-4f82-adfb-510983a8da64"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-2.png" },
                    { new Guid("f92c8566-c646-4e6f-b88f-b03f90090d7d"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-2.png" },
                    { new Guid("faca8dff-ad9e-4940-8330-905a5fbddce0"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-2.png" },
                    { new Guid("fbfd509a-6e54-4c7a-a55d-d6e0743ec4fe"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-2.png" },
                    { new Guid("fc6c35e5-26bd-4b3a-b0c5-bf48336243ad"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-1.png" },
                    { new Guid("fca56d68-b49f-4b61-a134-b03cfeb81c65"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-1.png" },
                    { new Guid("fd4b42f3-e3be-4d9e-849d-f68a6d6383f4"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-3.png" },
                    { new Guid("fdb7a486-42ec-444a-a082-a6ba38cd0627"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-2.png" },
                    { new Guid("ff3873c5-bb8e-49fb-bcca-6200e832a03c"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-1.png" }
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
