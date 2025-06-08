using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FestivalShoppingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoppers",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoppers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Shoppers_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Essential = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStatuses",
                columns: table => new
                {
                    ItemStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShopperId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStatuses", x => x.ItemStatusId);
                    table.ForeignKey(
                        name: "FK_ItemStatuses_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStatuses_Shoppers_ShopperId",
                        column: x => x.ShopperId,
                        principalTable: "Shoppers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "GuidId", "Name" },
                values: new object[] { new Guid("46c437cf-e112-4210-a63e-e3ebddbd9cc6"), "Festival Shopping List" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShoppingListId" },
                values: new object[,]
                {
                    { new Guid("1e99ba74-2d2e-4a4f-a950-dc93c96dd18f"), "Camping Gear", new Guid("46c437cf-e112-4210-a63e-e3ebddbd9cc6") },
                    { new Guid("8d04f075-f827-43bf-be47-de60895241b8"), "Food & Drinks", new Guid("46c437cf-e112-4210-a63e-e3ebddbd9cc6") },
                    { new Guid("ab1de9fa-dc24-4df1-bb49-2188a8dd8a72"), "Clothing", new Guid("46c437cf-e112-4210-a63e-e3ebddbd9cc6") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Essential", "Name", "Url" },
                values: new object[,]
                {
                    { new Guid("41b97414-1747-496c-bd60-0f2a62d27ed0"), new Guid("ab1de9fa-dc24-4df1-bb49-2188a8dd8a72"), true, "Rain Jacket", "https://example.com/rain-jacket" },
                    { new Guid("6a05f952-7a57-4a58-b5de-0484c92e3174"), new Guid("8d04f075-f827-43bf-be47-de60895241b8"), false, "Snacks", "https://example.com/snacks" },
                    { new Guid("6cd7e172-6f3c-49a5-9054-662e381e1138"), new Guid("1e99ba74-2d2e-4a4f-a950-dc93c96dd18f"), false, "Camping Stove", "https://example.com/camping-stove" },
                    { new Guid("72758284-559b-4817-bc83-e3dc3e86f881"), new Guid("1e99ba74-2d2e-4a4f-a950-dc93c96dd18f"), true, "Tent", "https://example.com/tent" },
                    { new Guid("8984a28f-dda8-4c90-a72a-fd72ed6f2621"), new Guid("ab1de9fa-dc24-4df1-bb49-2188a8dd8a72"), true, "Hiking Boots", "https://example.com/hiking-boots" },
                    { new Guid("acc89c5c-fe88-4eb5-97af-b1d1a10508ff"), new Guid("8d04f075-f827-43bf-be47-de60895241b8"), true, "Canned Food", "https://example.com/canned-food" },
                    { new Guid("d26bbe5b-0143-4df8-8cf3-5d1c5789f768"), new Guid("8d04f075-f827-43bf-be47-de60895241b8"), true, "Water Bottles", "https://example.com/water-bottles" },
                    { new Guid("ef8c36be-b2b5-49df-8f60-36321be8ce75"), new Guid("1e99ba74-2d2e-4a4f-a950-dc93c96dd18f"), true, "Sleeping Bag", "https://example.com/sleeping-bag" },
                    { new Guid("f9790305-4b63-4cf7-93cd-73748d3cb98b"), new Guid("ab1de9fa-dc24-4df1-bb49-2188a8dd8a72"), false, "Sunglasses", "https://example.com/sunglasses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShoppingListId",
                table: "Categories",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStatuses_ItemId",
                table: "ItemStatuses",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStatuses_ShopperId",
                table: "ItemStatuses",
                column: "ShopperId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoppers_ShoppingListId",
                table: "Shoppers",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemStatuses");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Shoppers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ShoppingLists");
        }
    }
}
