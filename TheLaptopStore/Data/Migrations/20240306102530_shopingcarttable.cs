using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheLaptopStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class shopingcarttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    laptopModel = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.userId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Laptop_laptopModel",
                        column: x => x.laptopModel,
                        principalTable: "Laptop",
                        principalColumn: "Model");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_laptopModel",
                table: "ShoppingCart",
                column: "laptopModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart");
        }
    }
}
