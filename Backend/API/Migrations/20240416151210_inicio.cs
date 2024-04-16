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
                name: "BasketItem",
                columns: table => new
                {
                    BasketItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Type = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.BasketItemId);
                });

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
                    { new Guid("0100092a-3301-43ba-9e13-991c3921ceb4"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-1.png" },
                    { new Guid("014419e6-2cf6-4ff1-b64a-04c0f43cae22"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-2.png" },
                    { new Guid("02967eb2-cd09-4d12-aa80-33f4a64ccd90"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-2.png" },
                    { new Guid("032ed69e-4009-4806-8422-061d2b8d4634"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-3.png" },
                    { new Guid("041ac986-7ba9-4084-9459-c74406d6dd8f"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-1.png" },
                    { new Guid("05c1f45a-a7e9-4409-9fb6-b2b7c4534ae2"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-1.png" },
                    { new Guid("05e7f5d5-821c-48ee-bf2e-fbbe203af6f8"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-3.png" },
                    { new Guid("060fa0d3-8080-4203-8fbb-25619c83a832"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-1.png" },
                    { new Guid("0761da72-91cf-4d75-81bf-d668a0aecfd4"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-2.png" },
                    { new Guid("08c22032-c157-4a2f-ae10-ca98dad07b34"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-2.png" },
                    { new Guid("093a6d75-58fe-4e94-8b0d-8a13680df824"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-3.png" },
                    { new Guid("099f0a9a-6a08-4310-9df5-05a908b650c8"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-2.png" },
                    { new Guid("0a879dce-d3f5-432f-93e4-1be9876b0cae"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-3.png" },
                    { new Guid("0cc92ddf-ec8b-4381-a779-14f51c3bfc15"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-1.png" },
                    { new Guid("0e70bde7-7a24-4d72-9d27-d5ae49844732"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-1.png" },
                    { new Guid("0eba3830-e2d1-4928-9cdb-a61d06103cde"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-1.png" },
                    { new Guid("0efe66d0-af81-4dee-a88e-d407bf765f5e"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-1.png" },
                    { new Guid("0fa26259-cad0-4141-b8c0-8498075f1c35"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-2.png" },
                    { new Guid("1534665e-c298-497e-b20e-ac6131da67d3"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-2.png" },
                    { new Guid("16443f5e-0cec-4084-aa62-4ac7631608b1"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-3.png" },
                    { new Guid("17ac8606-3d21-4df9-8eb7-6db6697ffbfa"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-2.png" },
                    { new Guid("17d75531-0459-4ee5-9c4d-4572d1e30ebc"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-1.png" },
                    { new Guid("184f33a6-0438-4fc3-bfcc-1601b10c9bb2"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-2.png" },
                    { new Guid("188fab77-86eb-4d3a-be02-4d4a515da9f9"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-2.png" },
                    { new Guid("1bd9dcfc-046b-4db3-b8be-5f0dc3c8159e"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-3.png" },
                    { new Guid("1d9053e3-f12f-464d-a665-c7037af5e998"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-3.png" },
                    { new Guid("1e5b5c1c-f01f-4825-b07d-cb8933cb9bc5"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-3.png" },
                    { new Guid("1fcc5058-810a-4e96-94ab-a96fe3ee8ca1"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-1.png" },
                    { new Guid("20b07f32-6c64-4fab-9cf3-44c3f26b41a8"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-2.png" },
                    { new Guid("21635d95-8bb4-4c10-b4a3-b5557766d51a"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-2.png" },
                    { new Guid("21781ca6-9f7f-4f02-888d-c8757cc72786"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-3.png" },
                    { new Guid("2237c455-f2ca-4d26-ab86-141ef8f8580f"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-1.png" },
                    { new Guid("22bae6ef-410d-4581-a138-e5d93bf73cb5"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-2.png" },
                    { new Guid("24063919-5334-47e6-8444-b0659595bc1c"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-3.png" },
                    { new Guid("24d3b6b7-52d2-4419-93b6-f7395261f8d4"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-2.png" },
                    { new Guid("2553cb0a-d31c-4397-a15b-71fdec41af98"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-2.png" },
                    { new Guid("2625e0ef-b599-4df4-bd6f-9967da30249c"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-3.png" },
                    { new Guid("26690408-876a-4e24-8092-9d1c93679894"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-1.png" },
                    { new Guid("277fed7e-3ca6-485f-bea6-14c77aac5241"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-1.png" },
                    { new Guid("282a530e-eb3f-4c96-a049-2d2163434946"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-1.png" },
                    { new Guid("2896055b-c6ab-45b3-9099-016a9a08e9fd"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-3.png" },
                    { new Guid("28f68cab-6e01-4cb6-a2c8-a0eea715d983"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-3.png" },
                    { new Guid("29ad36dc-4763-46fa-ae1e-592eea1a975c"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-2.png" },
                    { new Guid("2a51ebcd-0b2e-4edb-bc4a-03328015afc4"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-2.png" },
                    { new Guid("2b31a752-4353-480d-b353-3b8871936271"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-3.png" },
                    { new Guid("2b967992-5549-4328-9bca-b4cc57c88648"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-2.png" },
                    { new Guid("2c31cf46-e01f-4ac3-8f99-f8c738f520c7"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-2.png" },
                    { new Guid("2cf6be87-d4e0-4625-bcd3-046ee2556947"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-2.png" },
                    { new Guid("30b7e2f7-9922-4def-98f4-f25c4c86424d"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-1.png" },
                    { new Guid("320f34ea-6749-42ea-984c-162353081b82"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-3.png" },
                    { new Guid("359f9f76-ce23-4737-93b4-94d256b1d51f"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-2.png" },
                    { new Guid("35afa91a-7d2c-4213-9dbc-2aa7bee6507d"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-1.png" },
                    { new Guid("367f104c-c69c-425f-bb8d-004ceb7883b7"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-1.png" },
                    { new Guid("375fb42e-8153-48ce-bfa1-dfec65e6b727"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-1.png" },
                    { new Guid("37cb179f-381a-403c-b5ea-5d1700a2c9db"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-3.png" },
                    { new Guid("37d5981a-6b03-4f89-b113-3042bff4a91a"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-3.png" },
                    { new Guid("3a576e3d-c6ce-437d-859e-d85b4c6cce82"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-3.png" },
                    { new Guid("3c2089d1-0698-4d7f-a53b-9a3135d64a89"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-3.png" },
                    { new Guid("3cfe89af-bc6c-43c1-9bde-fb07005e12ec"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-3.png" },
                    { new Guid("3d75a407-e53e-4d1c-9141-565ae8a0bf03"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-1.png" },
                    { new Guid("40a04057-b8ed-462b-9025-d5cf8c15b8b2"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-1.png" },
                    { new Guid("41c7d14b-d87e-4027-afaf-ee495a5b64f0"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-3.png" },
                    { new Guid("4221015a-3da2-46c2-831e-bc9e8c1f3e06"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-3.png" },
                    { new Guid("438a989a-e4df-4dea-8d57-d02c402e3070"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-1.png" },
                    { new Guid("438f4260-c40e-493a-a723-366c3215b00b"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-3.png" },
                    { new Guid("44488f4b-06b3-4a8a-9c16-396042625ae4"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-3.png" },
                    { new Guid("444c6c3e-fda9-4278-9346-41b9593fcff6"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-1.png" },
                    { new Guid("46987eeb-3699-4bba-9e80-52f997056857"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-2.png" },
                    { new Guid("4755a2c4-6766-4e36-86b9-bfe7ff90d239"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-3.png" },
                    { new Guid("47b19e4b-7b71-4fd3-beb1-587d594883d8"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-2.png" },
                    { new Guid("482e1519-4d72-41e2-ae4c-c049b9bf8047"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-1.png" },
                    { new Guid("483454cb-ec77-4146-ad32-dbc340f4a0ac"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-3.png" },
                    { new Guid("48caec97-341a-4bae-9696-095e17da44cc"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-2.png" },
                    { new Guid("498351bf-303d-497d-a8cb-32b375d38b1e"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-2.png" },
                    { new Guid("49c8052a-cfc0-42e7-9f02-f94c72d79ae4"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-3.png" },
                    { new Guid("4b4c6664-103d-48c6-bb3f-3f8e677ce53e"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-1.png" },
                    { new Guid("4d711ba3-7efd-4cee-9a24-5b07fe20e6ec"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-1.png" },
                    { new Guid("4debcba3-9941-40ea-97cf-bc1278522fed"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-1.png" },
                    { new Guid("4ea45d32-354f-44af-8de0-ee64fa2ba2e4"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-2.png" },
                    { new Guid("51bb1ea8-6d4e-401e-864f-e9c9fa3ef424"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-3.png" },
                    { new Guid("51ca7265-726a-424b-888b-99f811b451da"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-1.png" },
                    { new Guid("51eec8f4-335c-4218-b896-fd7dcf83f398"), new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-915ded0b-e311-4fa1-85fd-9546ba0983dd-3.png" },
                    { new Guid("522c9926-37bd-4bf5-be9b-09985b942976"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-3.png" },
                    { new Guid("5230e0a0-3489-4228-9c5b-00a26be79c63"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-3.png" },
                    { new Guid("5412b8dd-f1c2-4709-b5fd-af9eed8eea1f"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-2.png" },
                    { new Guid("542eaa12-65e3-4ed0-b331-76905ddf8664"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-1.png" },
                    { new Guid("552f5dc6-5b60-4a52-a099-800d050311d7"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-1.png" },
                    { new Guid("554ef044-93fd-47ad-b790-a42da2d99fb5"), new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-6d22ff2a-f7a9-4759-9c0b-2cf8a061842e-3.png" },
                    { new Guid("55952ec9-47b8-43c8-b035-50101b12ebd9"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-3.png" },
                    { new Guid("592b9682-ba77-4903-83aa-3a8e9702b3bf"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-3.png" },
                    { new Guid("5a2a6b73-aafc-4188-a760-00affcd036db"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-1.png" },
                    { new Guid("5a87597b-c405-43fe-928b-780fa05b8b0e"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-2.png" },
                    { new Guid("5bb3dcf2-1c31-421d-afe3-f421b6ee5d66"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-3.png" },
                    { new Guid("5c46e907-aac8-44af-a5a0-1a66aa58758b"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-2.png" },
                    { new Guid("5d13dfab-3364-48b0-965a-b58eeea6c9f1"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-3.png" },
                    { new Guid("5d5fa53a-4afb-4a31-9db8-c7b5dc321195"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-2.png" },
                    { new Guid("5d87dcb4-2efd-43e6-af01-51ec5cfb0069"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-1.png" },
                    { new Guid("6069230f-9e34-4f11-9cfd-6832898eabd6"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-3.png" },
                    { new Guid("6121af44-accf-4a06-86cb-9484e3475f33"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-3.png" },
                    { new Guid("6135ec02-1beb-4d42-b07b-d0f742dfad0e"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-1.png" },
                    { new Guid("6155f45f-fbf3-44f4-aa26-f974dbd99f63"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-2.png" },
                    { new Guid("63fad675-2d7a-446c-8ef6-b2931b7cc557"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-3.png" },
                    { new Guid("64d0100b-4911-44b5-985b-61fa9c58d33d"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-2.png" },
                    { new Guid("65b5da73-8fb2-47ff-9a08-496b82421ed0"), new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"), "/Images/Products/Nike/Product-Nike-Remeras-Niñas-9eacb903-4d21-49f3-bc4e-49b70a4387f3-1.png" },
                    { new Guid("65c4496f-d496-4153-9282-039eb5c23466"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-2.png" },
                    { new Guid("65d83bbe-49d7-4d2f-b290-f74d4b9eb768"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-2.png" },
                    { new Guid("661865ab-ef46-438d-9d3d-e58d7ae257d2"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-3.png" },
                    { new Guid("661bfbdd-35e7-4e81-80d3-766b483a7cd7"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-2.png" },
                    { new Guid("67b17929-b4e5-4c57-9eef-e1f1cf0e5ffc"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-1.png" },
                    { new Guid("6a517140-a1a2-49d4-b9a2-3410b878a56f"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-2.png" },
                    { new Guid("6b03dfa3-52e2-49c1-8121-c27b4aff3ff5"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-1.png" },
                    { new Guid("6b2dc568-8920-45b9-8dcf-aeda91804893"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-1.png" },
                    { new Guid("6b78a035-9e03-4c4b-8edf-ecf3c9a971a9"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-3.png" },
                    { new Guid("6b85f6c5-d7e9-4372-a8f5-01cf0444cbc7"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-1.png" },
                    { new Guid("6b9ea672-1e9f-4d6f-8666-ff04f5d60f84"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-2.png" },
                    { new Guid("6be1baf5-b559-4961-ab3f-66b45785d7d0"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("6d25b2e0-a5c9-476a-8d1a-8cb5c2221645"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-1.png" },
                    { new Guid("6d5f15cb-23ce-4f7b-be7a-93ef3453757f"), new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niñas-b68432dd-7059-4885-a6ae-f5f323b62463-1.png" },
                    { new Guid("6da50284-f0fd-461f-99c6-17c644bbf8c3"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-1.png" },
                    { new Guid("6e7503d9-1441-42b9-9b86-bf70cd2a4aaa"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-1.png" },
                    { new Guid("709107dc-7bf8-429f-b075-18fd41d586ee"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-2.png" },
                    { new Guid("70b55080-a285-4924-a6bd-b625cad17efc"), new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-10c6cff5-d98c-48d6-85e1-175d7f7e5149-3.png" },
                    { new Guid("70e04dc8-2634-467a-bdee-ef9b8a68ae1a"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-2.png" },
                    { new Guid("73aab0f3-8107-4830-a471-1e7866214f5e"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-1.png" },
                    { new Guid("74c9188b-0034-4488-979b-a83e51fbb76b"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-3.png" },
                    { new Guid("76779515-2948-4a21-8100-c0a3a09ffd71"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-3.png" },
                    { new Guid("7685493b-ad70-4b4b-be20-e6f887ea2f11"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-2.png" },
                    { new Guid("79fd35ba-447e-4b25-993b-e319e2271a4a"), new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niñas-1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e-1.png" },
                    { new Guid("7a055fd0-6153-4743-932d-797931bb465d"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-1.png" },
                    { new Guid("7a3a995a-55fd-4207-984e-eb798a5d2471"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-1.png" },
                    { new Guid("7a9aa396-8a32-41fd-9f71-5511559d4ad9"), new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-918f7193-ccad-4ad5-b5f1-33e77588a77d-2.png" },
                    { new Guid("7ab23935-da6f-41dd-976b-070d4dda811f"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-1.png" },
                    { new Guid("7bb86dbc-5ad0-4653-b364-421deed90883"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-1.png" },
                    { new Guid("7bd2ab6c-0447-4377-aeec-e598629459a8"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-2.png" },
                    { new Guid("7d61d227-618e-4467-b3f1-a32de2a3b1f7"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-3.png" },
                    { new Guid("7d7536b2-ded0-413d-91cd-74a9c9fb41a0"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-1.png" },
                    { new Guid("7ead5364-83ab-4917-b841-cbe21127dce3"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-1.png" },
                    { new Guid("7f16db24-8707-4762-8405-dc8d30f5a8e0"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-2.png" },
                    { new Guid("7f8c7515-a70f-4329-8541-208d99c142ec"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-2.png" },
                    { new Guid("7f96973e-93aa-4016-8b94-3bfb0e9b730f"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-2.png" },
                    { new Guid("7fece68e-1c84-4e00-bd6b-03df7aa4a834"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-3.png" },
                    { new Guid("805aa51a-9cbc-4ab3-ac1a-b71a5066e189"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-2.png" },
                    { new Guid("80a7e02f-df28-4a28-becd-727ee1f8d79d"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-3.png" },
                    { new Guid("81120d6a-c038-4711-8b1f-cc6bfe9e4310"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-2.png" },
                    { new Guid("8186d597-2a8b-4bf1-8420-78779738e692"), new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc-2.png" },
                    { new Guid("82761646-899c-4ee3-aae4-05ad36151004"), new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niñas-e3676b6a-190b-4e72-bb64-ca5c636f321e-1.png" },
                    { new Guid("83ce88d9-745d-492a-b08e-bd83147a9dd9"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-2.png" },
                    { new Guid("84441aba-1555-45d6-a3cf-21b16d6d274d"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-3.png" },
                    { new Guid("858caf85-da72-43c7-a05d-6b10b4b2376e"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-1.png" },
                    { new Guid("859bd1a9-e65f-438e-a188-2851ba7f5d5d"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-3.png" },
                    { new Guid("85eb7e10-e1b3-46cc-ae01-7732ff2de798"), new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"), "/Images/Products/Puma/Product-Puma-Remeras-Niñas-bd54583c-534b-45b8-a8d2-ecfa27195c1d-2.png" },
                    { new Guid("864264c7-073d-4319-b59b-923d4a82c1c3"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-1.png" },
                    { new Guid("87518274-0b82-4e83-a5ab-7697d3b89a7e"), new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niñas-7cd84802-c771-4d1c-b17a-320d05ae81b8-2.png" },
                    { new Guid("8835ab14-a847-4aee-927c-fd59c1f47e0b"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-2.png" },
                    { new Guid("88485ccc-9e31-4847-938f-f6201951b5d5"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-1.png" },
                    { new Guid("89127aa4-dea4-4ea0-b1db-b146a246490a"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-3.png" },
                    { new Guid("897685e6-2cce-4bd6-85db-c8ba38043d62"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-3.png" },
                    { new Guid("8a195386-315b-48c6-94af-b6d0ff7eb3b5"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-2.png" },
                    { new Guid("8dfe2e25-007d-4f91-988e-08c8e5adc217"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-1.png" },
                    { new Guid("90b961e6-555a-4697-853e-4bc5e5167945"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-3.png" },
                    { new Guid("90f2be7f-64c5-41a7-872a-07f5d8e34518"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-2.png" },
                    { new Guid("93cc5ee6-2afd-4b36-b50a-441bf4f7c5d5"), new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-ef9069f0-638c-4291-a2b2-637d5b08fe77-3.png" },
                    { new Guid("93d00f32-5e98-4334-8d69-d78734e33de1"), new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-2.png" },
                    { new Guid("94593d53-ae49-4a14-9746-e2e211f0dad1"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-1.png" },
                    { new Guid("94a2c4ff-1689-4842-bca5-d1da08320d47"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-2.png" },
                    { new Guid("95aa0c80-d624-4f41-b916-721798426dbe"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-3.png" },
                    { new Guid("96808a88-fce8-4b22-9037-0aeb5621f866"), new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-b35995f9-43b3-49e9-8dfb-1aa1e154a2a9-3.png" },
                    { new Guid("97761946-f15b-4932-9646-e68cfe941e56"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-3.png" },
                    { new Guid("9a2c25cd-d861-4d69-b729-d9d434cbfe83"), new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-62fe85a1-3b51-46fa-9650-602b69f29fe9-3.png" },
                    { new Guid("9a6097e2-88ce-46c6-a0ab-a8f5b6a7ba24"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-2.png" },
                    { new Guid("9a69921d-b149-45eb-9c68-03d3f83c3355"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-1.png" },
                    { new Guid("9ab4f13d-bf51-484b-b54d-7e817238d0af"), new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-838edd99-f13f-43a6-8cd6-afbddf440a89-2.png" },
                    { new Guid("9af0ccca-67f2-411f-aab6-697f32a192e3"), new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"), "/Images/Products/Adidas/Product-Adidas-Remeras-Niños-f5b76376-3dd6-4cd0-936f-0391703cec10-3.png" },
                    { new Guid("9b63edb8-2e62-45cb-84b3-ba90d6fb32f5"), new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-7ed42256-f685-44c0-a3c5-b0b2c07bee12-2.png" },
                    { new Guid("9c035f9d-6a12-49f7-a40f-6909ea40ed25"), new Guid("cc91c201-d57d-488e-8f16-c423234a8260"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-cc91c201-d57d-488e-8f16-c423234a8260-3.png" },
                    { new Guid("9c6a6f16-da17-4564-b969-a5a81b6ad604"), new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-ed3d39e2-417d-43eb-99ad-864942355ca5-2.png" },
                    { new Guid("9c818db1-28ee-4151-8bc2-7ae615b31927"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-3.png" },
                    { new Guid("9d077155-4d39-4f65-ac5f-4501d58846d1"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-2.png" },
                    { new Guid("9d112f3d-615a-441a-b790-ecaa0b66fcfe"), new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-c617b2ad-3e1a-41ba-bbd7-567481a717b4-3.png" },
                    { new Guid("9e06b54a-f50a-4ca9-a541-dcae4277cde1"), new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-bba05e71-0cd0-48c7-bf1d-192707b77873-3.png" },
                    { new Guid("9f63d663-b638-4dd7-915f-abc54a4efd7e"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-1.png" },
                    { new Guid("a054916b-9399-42af-8c5e-a88f9b425580"), new Guid("c7160512-a504-4d24-bb65-e8357e591f89"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-c7160512-a504-4d24-bb65-e8357e591f89-2.png" },
                    { new Guid("a0b387b7-9a75-4f65-8eae-8326687c845c"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-1.png" },
                    { new Guid("a0f518ad-de06-45a3-8514-401c0aa926dd"), new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-5cac55bf-6b5a-4c34-b9de-88681596b4bf-3.png" },
                    { new Guid("a14c50fa-f2a8-4a4f-80fb-5a9ef94d48ad"), new Guid("418f8acd-c640-40d6-8f1d-084465af5300"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-418f8acd-c640-40d6-8f1d-084465af5300-2.png" },
                    { new Guid("a1ba46fb-94e4-4290-8f78-cf72897fe48f"), new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"), "/Images/Products/Fila/Product-Fila-Calzas-Hombre-a5a17788-615e-45f9-bcf8-4e31114caf27-2.png" },
                    { new Guid("a449fe32-6a89-4fc7-8511-ec0528fbb234"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-3.png" },
                    { new Guid("a46ded01-f5a0-49ec-8e87-7426172bf93c"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-1.png" },
                    { new Guid("a47b238a-d907-4bbe-a541-bd2f377091fc"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-2.png" },
                    { new Guid("a4d968c2-247e-458c-9b9d-a93617797b30"), new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-6761cc8a-5fd8-4b01-8b6a-944446f223e2-1.png" },
                    { new Guid("a69b596b-ae86-44b6-993d-e397e77079b6"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-3.png" },
                    { new Guid("a6b45fd2-d5af-42c7-bd53-914f6b564db2"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-2.png" },
                    { new Guid("a7414756-0a41-4e08-9e96-977bdb0aeb50"), new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"), "/Images/Products/Puma/Product-Puma-Calzas-Mujer-b537ce4f-fafa-4a16-99ad-fecac1a17384-2.png" },
                    { new Guid("a8aa362c-cb55-404c-b3eb-290e1401b347"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-1.png" },
                    { new Guid("a973a5fa-499f-48d4-979b-bf06536897d3"), new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-058f6760-7751-440c-bfcd-dcb0cf16fe4e-1.png" },
                    { new Guid("a9f097cc-a01c-4b5b-8928-7f2ab17b275a"), new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-e5c695b3-2517-4163-92f9-fd76762a0a5f-1.png" },
                    { new Guid("abef7ae7-69ad-4258-b74f-f79765d67ecf"), new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-4cbb9373-c51f-43d5-a88b-82941daec0c1-1.png" },
                    { new Guid("acc92706-9574-462e-8d8b-251c90c2a106"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-2.png" },
                    { new Guid("ad272d2b-36eb-4ba8-8090-8bc7e656b776"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-3.png" },
                    { new Guid("adf9d08a-0194-47a9-832d-c773d4b4fda6"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-1.png" },
                    { new Guid("aece1fd8-4dbd-46fd-8b7d-6ebe5a785ea4"), new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Niños-474f92ee-95ac-4e69-900a-0ab296e3b296-1.png" },
                    { new Guid("afbac351-4f65-4018-ba37-f095c1f03787"), new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"), "/Images/Products/Reebok/Product-Reebok-Calzas-Mujer-01ebe9c3-d238-4dbc-81b0-0abe238878e2-1.png" },
                    { new Guid("aff8e0d1-be52-4ca5-a853-3e520e076791"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-1.png" },
                    { new Guid("b04e5595-df25-4c17-826e-72adae87646e"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-1.png" },
                    { new Guid("b0e81cae-0969-45f6-8c42-eaae2fe4a4c5"), new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-aa5ffbd0-841f-4954-abe7-b619a4b6a216-3.png" },
                    { new Guid("b13478ee-0488-4a93-b862-d9db40d83984"), new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-e108a5b9-d0d8-4d8e-a6d7-172404336125-1.png" },
                    { new Guid("b2405a9d-6ecc-4831-855c-2b5b13ee205f"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-2.png" },
                    { new Guid("b318cef6-07a6-45e5-86bc-9b02100bea68"), new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niños-bf86d111-a57e-44b0-b2e3-5195c73507a9-1.png" },
                    { new Guid("b425fe68-03b5-4f51-84cd-fb2e6ba3ed28"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-1.png" },
                    { new Guid("b528c015-15a5-4bb6-81c1-8127c94c480b"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-1.png" },
                    { new Guid("b5744469-79c6-4511-a98f-c58095cd7f0c"), new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-8b498a6e-dd85-4cf8-aa62-4a803a98d9a0-3.png" },
                    { new Guid("b7eb4ad7-1d8f-4098-a31e-c64a8464040c"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-3.png" },
                    { new Guid("b8ad673c-bbbd-40ea-96c5-1ef3fc94000e"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-1.png" },
                    { new Guid("b9bbaca7-157d-4b74-a916-6a21c79e01e5"), new Guid("f58b815e-12b1-4499-8f04-bb6725034853"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niñas-f58b815e-12b1-4499-8f04-bb6725034853-3.png" },
                    { new Guid("ba788a26-a710-4b7f-84e1-0008ea08e96d"), new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb-2.png" },
                    { new Guid("baace9d6-261d-4597-b9a2-210e7e14d647"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-1.png" },
                    { new Guid("bab33a45-3b57-4c3a-8cbb-2415880dd378"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-2.png" },
                    { new Guid("bad46864-4c11-4879-ac99-d2216dc7c0a3"), new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Hombre-bd73387d-9db3-4933-baab-7330ee1f741c-2.png" },
                    { new Guid("bb140842-3404-4068-b562-5eb728cb905e"), new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-54f52aed-e8e6-46f6-a363-1097b0b02e38-1.png" },
                    { new Guid("bb36e072-80b9-44e6-8c97-62b1991f8948"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Niños-4adb6f3d-c138-43f6-b2fb-0ff0ec466381-2.png" },
                    { new Guid("bb4086bb-456f-47da-84af-4d3e34dab17e"), new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Mujer-2df90aaf-900c-410a-bf6b-3c8da468f600-2.png" },
                    { new Guid("bbc1d3ef-d5ee-4663-b7dd-3671ef62c11f"), new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-1a8ec708-e252-4e9f-88eb-3b4b832ec350-2.png" },
                    { new Guid("bc3f99ca-c4d7-4e6a-8ada-54b64ca54a90"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-1.png" },
                    { new Guid("bdb67580-8a2a-48c3-8a98-d7a6ac930c77"), new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-671c59f3-0d7d-4e0b-81ae-c543368b605d-2.png" },
                    { new Guid("bec0d7d4-6e9b-4bf7-8fa2-01767e4126cd"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-1.png" },
                    { new Guid("bf0a2a44-dfe6-4129-9538-c104154fae25"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-2.png" },
                    { new Guid("bf138e60-2041-45ae-9219-8cc9bace97f8"), new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Hombre-a08a0c1c-f882-4a8e-af0b-b889e87cc93d-2.png" },
                    { new Guid("bf41848c-c53c-49ed-a08f-ba2b10ff7d9d"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-1.png" },
                    { new Guid("bf634522-7f72-4c51-9da7-7fc87ad2fc4c"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-3.png" },
                    { new Guid("bfe5a3ce-4efe-47c6-ba24-b554df62d407"), new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"), "/Images/Products/Fila/Product-Fila-Zapatillas-Niñas-7617b910-b3e5-4d52-8041-3a3507cc052e-1.png" },
                    { new Guid("bff23ca1-5b3a-49d0-a3ae-feda202d36c3"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-3.png" },
                    { new Guid("c1449e14-f13c-401c-8a76-9e8da7d24b0c"), new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"), "/Images/Products/Nike/Product-Nike-Remeras-Mujer-e4185b6c-15da-44f7-a48c-3520f3bb5354-3.png" },
                    { new Guid("c29e0e77-36ad-4f8e-b12d-5b0fe20b309a"), new Guid("3a13a2d8-956e-400d-9213-9893dd929897"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-3a13a2d8-956e-400d-9213-9893dd929897-3.png" },
                    { new Guid("c358b7c8-e032-4435-a01f-154d689c7811"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-2.png" },
                    { new Guid("c4ef2609-12c5-4901-8b31-9bfddb9d56a5"), new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niños-4c498b21-648d-443e-a7ac-5a7c61da8a83-3.png" },
                    { new Guid("c505fd89-1a0c-405c-a763-dcf8deeddf02"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-1.png" },
                    { new Guid("c72afc2b-5cc7-4b74-a0b8-3c409fb8604a"), new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Hombre-875cf1ea-ad27-409b-a03e-51b2a3f4bb6c-2.png" },
                    { new Guid("c819bde4-ccb0-4cee-9937-53c9e208dd65"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-1.png" },
                    { new Guid("c983e9a3-6774-4f8b-9183-e07c26b7abf9"), new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-d72edb9a-9483-4cb6-a6ac-70044b28449d-1.png" },
                    { new Guid("caa7dc00-a50e-409e-a8e7-966160aba08d"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-1.png" },
                    { new Guid("ccb62321-7c9b-4be3-87bc-10f4ce3601d3"), new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"), "/Images/Products/Reebok/Product-Reebok-Remeras-Hombre-2cf5de04-2161-4f05-b978-31e332a827d8-1.png" },
                    { new Guid("ccc79750-4df8-48e4-8e4d-8fba5a3ad69b"), new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Mujer-087237c0-e590-44f5-806a-9ed8a5fdccc4-2.png" },
                    { new Guid("cf23abba-e7b0-4dc3-a72b-3057b8cdfbb3"), new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-e9b31ad4-5e25-42bf-9cc2-453814d552ee-1.png" },
                    { new Guid("cf4a6c7b-651e-43d8-b2d5-8f13cb68b42b"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-3.png" },
                    { new Guid("cff64c1d-d7d9-4aa2-84b3-abb7033a5b34"), new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"), "/Images/Products/Fila/Product-Fila-Remeras-Hombre-f1e7e785-d70a-4246-9b77-8253fb07e321-2.png" },
                    { new Guid("d1b620a1-d575-4d10-9be5-058628226252"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-2.png" },
                    { new Guid("d1e8f18d-f752-4aae-a0b8-2a2c2bf99df6"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-3.png" },
                    { new Guid("d2d3476c-40b1-4537-aae9-bcc09d3d8146"), new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niñas-4ee0914d-5aa7-4968-905f-7bd2750cb2e6-3.png" },
                    { new Guid("d3d7d436-7819-4c9e-a1d5-91210edd428a"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-3.png" },
                    { new Guid("d3e2bf76-a57c-4d0a-a6d9-c8b918d8af81"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-1.png" },
                    { new Guid("d3eb9329-d538-479f-a925-cc08d241d201"), new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niños-6b00b41e-a07c-4a7b-ba49-a01503ef6269-3.png" },
                    { new Guid("d3f87690-48a2-4086-bd9a-4920312c1618"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-3.png" },
                    { new Guid("d4d18eaa-3789-4c71-b11d-7bcd35779fa0"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-2.png" },
                    { new Guid("d56ed57e-4200-4637-b21e-98c727f6b7e5"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-2.png" },
                    { new Guid("d6ad0f5f-4b59-4819-ada6-a18126a99b1a"), new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Mujer-e67ce8dd-20c9-4205-b500-90fd166fed81-3.png" },
                    { new Guid("d6fc4795-d2cb-49b1-9f50-20472be380d4"), new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-64ef8009-bdf3-4feb-a153-aaee4073c606-1.png" },
                    { new Guid("d7eeb65c-62e2-44bc-a6fc-3598abcdf04c"), new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"), "/Images/Products/Nike/Product-Nike-Tops-Mujer-c49d0933-ac5c-4e7a-8fb8-afe275fb59ff-1.png" },
                    { new Guid("d8610831-39bb-4a7c-a606-9800cf4a263d"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-3.png" },
                    { new Guid("dade69e6-e5d3-48cb-b893-3841910c00e9"), new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-49f8f920-4610-440f-ba71-a1c1ed6ddb8d-1.png" },
                    { new Guid("db32a973-4745-4eee-965d-2c84b3ecb790"), new Guid("0c92c422-5970-430e-a2b7-800313abf519"), "/Images/Products/Puma/Product-Puma-Remeras-Mujer-0c92c422-5970-430e-a2b7-800313abf519-1.png" },
                    { new Guid("dc40d6fa-1708-42c5-ad60-0bb8cfc085a9"), new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Hombre-029d34cc-06fd-44b7-a9f2-5270e754d788-2.png" },
                    { new Guid("dcc02471-65cc-4f76-9e24-70236703c8e6"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-2.png" },
                    { new Guid("dd8dda3f-9581-4509-a1b3-8234a55f672b"), new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"), "/Images/Products/Puma/Product-Puma-Buzos y Camperas-Hombre-67408bf6-6fa2-4a48-8b50-24552cfe88c1-3.png" },
                    { new Guid("ddc47125-8703-4734-9469-a226082f7b48"), new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"), "/Images/Products/Nike/Product-Nike-Buzos y Camperas-Niños-ee616c82-bc73-4316-9b30-ee25833805b3-3.png" },
                    { new Guid("dec92d38-a56e-4567-918b-91f75d21223e"), new Guid("f94933b0-b851-41ec-85a6-62b172aad404"), "/Images/Products/Reebok/Product-Reebok-Buzos y Camperas-Mujer-f94933b0-b851-41ec-85a6-62b172aad404-2.png" },
                    { new Guid("df308188-1575-4a97-9f42-b05bcf560592"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-1.png" },
                    { new Guid("e01829f6-e7fd-48a5-a404-0d256f864f03"), new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-2cba3f53-408e-4ed5-9b16-5c3a2ff10f70-2.png" },
                    { new Guid("e11be535-6f01-464c-8f51-7f785c942008"), new Guid("1670707a-10e8-49d1-a071-fc427d319c10"), "/Images/Products/Adidas/Product-Adidas-Calzas-Mujer-1670707a-10e8-49d1-a071-fc427d319c10-2.png" },
                    { new Guid("e35ac957-77cd-4820-9c2c-8a4c880d646d"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-1.png" },
                    { new Guid("e47023c9-75c0-4587-a58f-5dd2f32e5626"), new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-2962fbca-53b3-4393-88ad-2642a49b8492-1.png" },
                    { new Guid("e4ccaa83-0aee-45f8-8cca-4d8d23e3483f"), new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-26fbd842-584a-4a7a-ae3a-9cd26e637221-3.png" },
                    { new Guid("e5f1d652-f621-42a4-b9bf-30e3111cad3d"), new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Mujer-3660b93b-5430-421a-899d-adc6ac3514fd-1.png" },
                    { new Guid("e6f1516b-1395-4964-8f25-bc962bcfa24c"), new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Niños-862057bb-3275-43a5-98ee-9650f3f9c45f-2.png" },
                    { new Guid("e80011f4-86c5-4292-9c03-dc345f16e766"), new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-991f1ffc-b151-421f-950a-8948d8e6cd86-3.png" },
                    { new Guid("e8d2fb14-1427-42f1-a91c-30ec2394ca8f"), new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"), "/Images/Products/Nike/Product-Nike-Zapatillas-Mujer-5d6f08f0-fce2-4e2e-80e7-961619d48788-1.png" },
                    { new Guid("ea4366a0-db01-4766-b728-895006c0a0f4"), new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"), "/Images/Products/Fila/Product-Fila-Remeras-Mujer-6f655ea7-e257-481f-94a3-3ef7d8c4c46e-2.png" },
                    { new Guid("ecaaffc3-7caf-4830-8aa1-078c6748ab0e"), new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"), "/Images/Products/Nike/Product-Nike-Calzas-Mujer-19f7af3a-3576-4f83-a3b6-b1f51729d3f3-1.png" },
                    { new Guid("ee19f67b-5f91-47e2-b22c-6483c6eeda0f"), new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"), "/Images/Products/Puma/Product-Puma-Tops-Mujer-73387c1e-6507-4078-988d-30b2f91e8ca9-3.png" },
                    { new Guid("ee690f9b-99f4-44c9-ab04-6f7b5be2182b"), new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"), "/Images/Products/Fila/Product-Fila-Zapatillas-Mujer-abd609da-bfcf-4194-9c19-d61a3eab5fcb-1.png" },
                    { new Guid("ef4afc79-2318-4d74-b094-2521c549016f"), new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Niñas-02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5-3.png" },
                    { new Guid("efe70695-97f0-46b0-b37f-8716e80ebb69"), new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"), "/Images/Products/Reebok/Product-Reebok-Tops-Mujer-f84976af-60b2-4dfa-8613-2139f7c681f8-2.png" },
                    { new Guid("f00379e2-48ca-43f9-8701-13f60e511b98"), new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"), "/Images/Products/Fila/Product-Fila-Remeras-Niñas-c191621c-6345-4b75-9fea-18fdfe9ad100-2.png" },
                    { new Guid("f0da3fd9-eaa6-4e4e-89dd-fdeb7537b2c2"), new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"), "/Images/Products/Fila/Product-Fila-Zapatillas-Hombre-7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b-1.png" },
                    { new Guid("f190f276-72d6-44d7-9426-76defeb6a8fb"), new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"), "/Images/Products/Fila/Product-Fila-Tops-Mujer-4c3b847d-2c63-44b9-9720-9d93744dadb2-3.png" },
                    { new Guid("f2728f87-2498-4d8f-9698-409d13af036d"), new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Mujer-3d09411f-28af-4aee-bd2b-b0ad0630b25e-2.png" },
                    { new Guid("f37007e0-fbc3-42a6-a38b-a5dd550d048d"), new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Hombre-ff0b7b2c-abd2-4bae-9b81-43211a47b3ed-1.png" },
                    { new Guid("f4514f97-2378-47af-9d23-738e38db034e"), new Guid("700fb128-5017-41ca-9221-765c3c3d9629"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-700fb128-5017-41ca-9221-765c3c3d9629-1.png" },
                    { new Guid("f45f879d-42bc-4850-abf3-323b013aa8a2"), new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"), "/Images/Products/Adidas/Product-Adidas-Zapatillas-Mujer-ec751372-dd49-41fd-baf7-7f51099d273a-2.png" },
                    { new Guid("f4c14867-f0c1-4c47-afac-1585bdfa5ebc"), new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-5deda8f6-2fd4-41fc-bdd2-3dec8330af3e-2.png" },
                    { new Guid("f6159c41-7984-4622-856a-9f03455df54c"), new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"), "/Images/Products/Adidas/Product-Adidas-Remeras-Mujer-29c7841e-2f15-4bcd-8ae3-bb3a8bce478d-2.png" },
                    { new Guid("f6f25ffa-d88c-46fd-9ffd-c3b3d8b9d85f"), new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"), "/Images/Products/Puma/Product-Puma-Remeras-Niños-f43ce520-c5bd-4cfc-a883-c2f66cc0e371-3.png" },
                    { new Guid("f7a2469b-6996-4e80-8103-fc271c15c455"), new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"), "/Images/Products/Fila/Product-Fila-Calzas-Mujer-e0b585b5-886a-483e-a75e-5d183b30b4af-1.png" },
                    { new Guid("f8a98091-c754-4b7c-b3a4-1233ea834414"), new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"), "/Images/Products/Adidas/Product-Adidas-Calzas-Hombre-6c62b16f-af56-4a69-aa7d-f769c70facb0-1.png" },
                    { new Guid("f8b985f1-dcc6-48ac-a86f-7b0db53782dd"), new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"), "/Images/Products/Nike/Product-Nike-Zapatillas-Niñas-e2db1b89-6662-4e1c-992a-500b485c505f-2.png" },
                    { new Guid("f9c9eb5c-e8ed-4dd0-b0ed-0361f0a28f49"), new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"), "/Images/Products/Nike/Product-Nike-Remeras-Niños-08058bbb-9553-4a5e-84f7-7cb3ec5440dd-2.png" },
                    { new Guid("fa32c61f-9cb9-4da4-83dd-8ad93b0777d2"), new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"), "/Images/Products/Nike/Product-Nike-Remeras-Hombre-8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc-3.png" },
                    { new Guid("faba3389-5fd2-4eb7-9946-d190e24f44a5"), new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"), "/Images/Products/Nike/Product-Nike-Zapatillas-Hombre-71ab1383-8f2f-4bf5-9619-c49703653021-3.png" },
                    { new Guid("fae2bfd3-43ce-440a-9d4d-f7c95f131195"), new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"), "/Images/Products/Puma/Product-Puma-Zapatillas-Mujer-4a94b629-2fbe-47dd-9a69-f487f1ef125b-2.png" },
                    { new Guid("fb471f4e-fe36-4765-bdd7-0e4a4ad82a7b"), new Guid("39e394fc-1afe-4969-8064-bc196834af14"), "/Images/Products/Reebok/Product-Reebok-Zapatillas-Hombre-39e394fc-1afe-4969-8064-bc196834af14-2.png" },
                    { new Guid("fc71e8e5-c2c0-4139-8efe-9b927f45aeea"), new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"), "/Images/Products/Puma/Product-Puma-Zapatillas-Hombre-01591ef9-277b-4e32-bfd3-03226b4f5b33-3.png" },
                    { new Guid("fc72dfa1-8d99-4311-9f03-72c564ed84f6"), new Guid("acce2896-28b7-4995-a8e6-a5f800362499"), "/Images/Products/Fila/Product-Fila-Remeras-Niños-acce2896-28b7-4995-a8e6-a5f800362499-3.png" },
                    { new Guid("fc759be9-01e5-4cb7-a427-1f3da400f37e"), new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"), "/Images/Products/Reebok/Product-Reebok-Remeras-Mujer-7e76479a-8f23-4dda-aaaa-888a3d0797ea-1.png" },
                    { new Guid("fca0985f-641f-4b01-ae8c-eb054e76c726"), new Guid("fb25a719-2394-4987-b092-715e9f44005a"), "/Images/Products/Adidas/Product-Adidas-Tops-Mujer-fb25a719-2394-4987-b092-715e9f44005a-2.png" },
                    { new Guid("fdae6251-61a3-48d4-b039-329b6bbae3fd"), new Guid("a64d4099-646e-4691-9e48-76726984e83d"), "/Images/Products/Puma/Product-Puma-Remeras-Hombre-a64d4099-646e-4691-9e48-76726984e83d-1.png" },
                    { new Guid("febbfc01-9324-4a71-b35c-ebb8e1e504d6"), new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"), "/Images/Products/Adidas/Product-Adidas-Buzos y Camperas-Niños-4287b952-5edc-43bb-bb61-fc42d2e51f14-2.png" },
                    { new Guid("fec5d721-0047-4e4e-a162-20dc948914f9"), new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"), "/Images/Products/Fila/Product-Fila-Buzos y Camperas-Hombre-8dbb6d66-dfc2-4144-9271-aeb099c030b4-2.png" }
                });

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
                name: "IX_OrderItems_OrdersOrderId",
                table: "OrderItems",
                column: "OrdersOrderId");

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
