using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furniture.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_cardItem_dbObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItem_Cards_CardId",
                table: "CardItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CardItem_Products_ProductId",
                table: "CardItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardItem",
                table: "CardItem");

            migrationBuilder.RenameTable(
                name: "CardItem",
                newName: "CardItems");

            migrationBuilder.RenameIndex(
                name: "IX_CardItem_ProductId",
                table: "CardItems",
                newName: "IX_CardItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CardItem_CardId",
                table: "CardItems",
                newName: "IX_CardItems_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardItems",
                table: "CardItems",
                column: "CardItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Products_ProductId",
                table: "CardItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Products_ProductId",
                table: "CardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardItems",
                table: "CardItems");

            migrationBuilder.RenameTable(
                name: "CardItems",
                newName: "CardItem");

            migrationBuilder.RenameIndex(
                name: "IX_CardItems_ProductId",
                table: "CardItem",
                newName: "IX_CardItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CardItems_CardId",
                table: "CardItem",
                newName: "IX_CardItem_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardItem",
                table: "CardItem",
                column: "CardItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardItem_Cards_CardId",
                table: "CardItem",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardItem_Products_ProductId",
                table: "CardItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
