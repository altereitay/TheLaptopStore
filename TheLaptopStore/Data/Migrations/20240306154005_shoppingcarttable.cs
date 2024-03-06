using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheLaptopStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcarttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Laptop_laptopModel",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_laptopModel",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<string>(
                name: "laptopModel",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                columns: new[] { "laptopModel", "userId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Laptop_laptopModel",
                table: "ShoppingCart",
                column: "laptopModel",
                principalTable: "Laptop",
                principalColumn: "Model",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Laptop_laptopModel",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<string>(
                name: "laptopModel",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_laptopModel",
                table: "ShoppingCart",
                column: "laptopModel");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Laptop_laptopModel",
                table: "ShoppingCart",
                column: "laptopModel",
                principalTable: "Laptop",
                principalColumn: "Model");
        }
    }
}
