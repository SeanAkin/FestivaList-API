using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FestivalShoppingApi.Data.Data.Migrations
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
                values: new object[] { new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "Festival Shopping List" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShoppingListId" },
                values: new object[,]
                {
                    { new Guid("142295b9-ea08-4c36-ae62-abccdd5750fd"), "Camping Gear", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778") },
                    { new Guid("814ecaaf-d9ce-4cc1-a56e-8e1eeb88e4eb"), "Food & Drinks", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778") },
                    { new Guid("818f8e2f-6f65-4ac7-91f1-b49e3b6ecef6"), "Clothing", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Essential", "Name", "ShoppingListId", "Url" },
                values: new object[,]
                {
                    { new Guid("4b5f175b-4929-48f3-a717-225c8888b8f3"), new Guid("142295b9-ea08-4c36-ae62-abccdd5750fd"), false, "Camping Stove", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/camping-stove" },
                    { new Guid("4bd7a802-314a-4bd4-88c3-bbc9cc039afc"), new Guid("142295b9-ea08-4c36-ae62-abccdd5750fd"), true, "Sleeping Bag", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/sleeping-bag" },
                    { new Guid("5c47049f-846c-42f3-9290-e5a778cea53d"), new Guid("814ecaaf-d9ce-4cc1-a56e-8e1eeb88e4eb"), true, "Water Bottles", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/water-bottles" },
                    { new Guid("861dbde2-ec71-454e-a3f3-0c3349ce4002"), new Guid("814ecaaf-d9ce-4cc1-a56e-8e1eeb88e4eb"), true, "Canned Food", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/canned-food" },
                    { new Guid("a1700298-391d-4431-a34b-790595ae96cb"), new Guid("814ecaaf-d9ce-4cc1-a56e-8e1eeb88e4eb"), false, "Snacks", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/snacks" },
                    { new Guid("b20c0ea7-98f9-4af9-81aa-059a782c6506"), new Guid("142295b9-ea08-4c36-ae62-abccdd5750fd"), true, "Tent", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/tent" },
                    { new Guid("b63523c2-57b4-415b-b5cd-8e617dd20196"), new Guid("818f8e2f-6f65-4ac7-91f1-b49e3b6ecef6"), false, "Sunglasses", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/sunglasses" },
                    { new Guid("ebf8dd16-08d3-4da9-bd59-b28778583b8b"), new Guid("818f8e2f-6f65-4ac7-91f1-b49e3b6ecef6"), true, "Hiking Boots", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/hiking-boots" },
                    { new Guid("f70d9891-c283-4dad-b82b-311a8a61ac1d"), new Guid("818f8e2f-6f65-4ac7-91f1-b49e3b6ecef6"), true, "Rain Jacket", new Guid("c945b1a9-9a47-4bcd-9a11-3ec930d2c778"), "https://example.com/rain-jacket" }
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
