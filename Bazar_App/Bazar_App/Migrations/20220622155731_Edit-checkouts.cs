using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar_App.Migrations
{
    public partial class Editcheckouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Checkout",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_CartId",
                table: "Checkout",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_UserId",
                table: "Checkout",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_AspNetUsers_UserId",
                table: "Checkout",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Carts_CartId",
                table: "Checkout",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_AspNetUsers_UserId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Carts_CartId",
                table: "Checkout");

            migrationBuilder.DropIndex(
                name: "IX_Checkout_CartId",
                table: "Checkout");

            migrationBuilder.DropIndex(
                name: "IX_Checkout_UserId",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Checkout");
        }
    }
}
