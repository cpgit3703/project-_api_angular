using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseSale.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_User_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Category_CategoryId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Donor_DonorId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Prize_Gift_GiftId",
                table: "Prize");

            migrationBuilder.DropForeignKey(
                name: "FK_Prize_User_UserId",
                table: "Prize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prize",
                table: "Prize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gift",
                table: "Gift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donor",
                table: "Donor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Prize",
                newName: "Prizes");

            migrationBuilder.RenameTable(
                name: "Gift",
                newName: "Gifts");

            migrationBuilder.RenameTable(
                name: "Donor",
                newName: "Donors");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categorys");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "Baskets");

            migrationBuilder.RenameIndex(
                name: "IX_Prize_UserId",
                table: "Prizes",
                newName: "IX_Prizes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Prize_GiftId",
                table: "Prizes",
                newName: "IX_Prizes_GiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_DonorId",
                table: "Gifts",
                newName: "IX_Gifts_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_CategoryId",
                table: "Gifts",
                newName: "IX_Gifts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_UserId",
                table: "Baskets",
                newName: "IX_Baskets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Categorys_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonorId",
                table: "Gifts",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Gifts_GiftId",
                table: "Prizes",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Users_UserId",
                table: "Prizes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Categorys_CategoryId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonorId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Gifts_GiftId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Users_UserId",
                table: "Prizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Prizes",
                newName: "Prize");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "Gift");

            migrationBuilder.RenameTable(
                name: "Donors",
                newName: "Donor");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "Basket");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_UserId",
                table: "Prize",
                newName: "IX_Prize_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_GiftId",
                table: "Prize",
                newName: "IX_Prize_GiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_DonorId",
                table: "Gift",
                newName: "IX_Gift_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gift",
                newName: "IX_Gift_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_UserId",
                table: "Basket",
                newName: "IX_Basket_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prize",
                table: "Prize",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gift",
                table: "Gift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donor",
                table: "Donor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_User_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Category_CategoryId",
                table: "Gift",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Donor_DonorId",
                table: "Gift",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prize_Gift_GiftId",
                table: "Prize",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prize_User_UserId",
                table: "Prize",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
