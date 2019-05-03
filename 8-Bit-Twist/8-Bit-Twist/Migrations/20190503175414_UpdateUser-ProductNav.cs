using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_Bit_Twist.Migrations
{
    public partial class UpdateUserProductNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_ApplicationUser_UserId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ApplicationUserID",
                table: "Baskets",
                column: "ApplicationUserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_ApplicationUser_ApplicationUserID",
                table: "Baskets",
                column: "ApplicationUserID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_ApplicationUser_ApplicationUserID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ApplicationUserID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserID",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Baskets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_ApplicationUser_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
