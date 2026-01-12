using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseSale.Migrations
{
    /// <inheritdoc />
    public partial class Initialreuwi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountNormalCard",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TypeCard",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "CountSpecialCard",
                table: "Packages",
                newName: "CountCard");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CountCard",
                table: "Packages",
                newName: "CountSpecialCard");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CountNormalCard",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeCard",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
