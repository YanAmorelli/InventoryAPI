using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryDescription", "InventoryName" },
                values: new object[] { 1, "This inventory is a mock inventory just for test", "Test" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BuyPrice", "Description", "InventoryId", "Name", "Quantity", "SellPrice" },
                values: new object[,]
                {
                    { 1, 100, "this item is a mock item just for test", 1, "test", 50, 150 },
                    { 2, 100, "this item is a mock item just for test", 1, "test", 50, 150 },
                    { 3, 100, "this item is a mock item just for test", 1, "test", 50, 150 },
                    { 4, 100, "this item is a mock item just for test", 1, "test", 50, 150 },
                    { 5, 100, "this item is a mock item just for test", 1, "test", 50, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
