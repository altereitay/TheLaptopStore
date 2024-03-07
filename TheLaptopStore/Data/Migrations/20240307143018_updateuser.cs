using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheLaptopStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_AspNetUsers_ApplicationUserId",
                table: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_CreditCard_ApplicationUserId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CreditCard");

            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CreditCardNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ExpDateMonth",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpDateYear",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpDateMonth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpDateYear",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CreditCard",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_ApplicationUserId",
                table: "CreditCard",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_AspNetUsers_ApplicationUserId",
                table: "CreditCard",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
