using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseSale.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBasketIdFromGift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Baskets_BasketId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_BasketId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Gifts");

            migrationBuilder.AddColumn<string>(
                name: "GiftsId",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftsId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Gifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_BasketId",
                table: "Gifts",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Baskets_BasketId",
                table: "Gifts",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
