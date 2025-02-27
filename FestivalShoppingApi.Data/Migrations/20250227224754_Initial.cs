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
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Essential = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Items_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "GuidId", "Name" },
                values: new object[] { new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "Festival Shopping List" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShoppingListId" },
                values: new object[,]
                {
                    { new Guid("3e5f85d9-e0fd-4266-aa65-25f07bc0fea9"), "Food & Drinks", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857") },
                    { new Guid("57b096f9-f827-420c-927c-ed39cd9cd997"), "Clothing", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857") },
                    { new Guid("892a6935-17e0-4230-9b76-58385a584394"), "Camping Gear", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Essential", "Name", "ShoppingListId", "Url" },
                values: new object[,]
                {
                    { new Guid("07db6b6c-9d46-4de1-9c6e-0a318e307322"), new Guid("3e5f85d9-e0fd-4266-aa65-25f07bc0fea9"), false, "Snacks", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/snacks" },
                    { new Guid("3d7b6cdd-a194-45a5-a439-9b3ad66fefb7"), new Guid("892a6935-17e0-4230-9b76-58385a584394"), true, "Sleeping Bag", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/sleeping-bag" },
                    { new Guid("5b4cfc6f-2e76-4a44-888f-2b8413370fcd"), new Guid("3e5f85d9-e0fd-4266-aa65-25f07bc0fea9"), true, "Canned Food", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/canned-food" },
                    { new Guid("75546a6d-8a55-4e79-ab43-033e3b7b5d1d"), new Guid("892a6935-17e0-4230-9b76-58385a584394"), true, "Tent", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/tent" },
                    { new Guid("966129e9-d399-4179-ae86-8a7b38d258e0"), new Guid("57b096f9-f827-420c-927c-ed39cd9cd997"), true, "Rain Jacket", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/rain-jacket" },
                    { new Guid("e0645387-9e53-4924-82e5-8f6a05280c83"), new Guid("3e5f85d9-e0fd-4266-aa65-25f07bc0fea9"), true, "Water Bottles", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/water-bottles" },
                    { new Guid("ea2bf610-fe2a-4c0f-9e4e-37474153a785"), new Guid("57b096f9-f827-420c-927c-ed39cd9cd997"), false, "Sunglasses", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/sunglasses" },
                    { new Guid("f25a8604-641a-4636-8ba2-083d08bea718"), new Guid("57b096f9-f827-420c-927c-ed39cd9cd997"), true, "Hiking Boots", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/hiking-boots" },
                    { new Guid("f82f2378-0e64-4f3f-868f-e9d6d23f69cc"), new Guid("892a6935-17e0-4230-9b76-58385a584394"), false, "Camping Stove", new Guid("a169ab83-66df-4d32-995b-fe0467c1d857"), "https://example.com/camping-stove" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShoppingListId",
                table: "Categories",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ShoppingLists");
        }
    }
}
