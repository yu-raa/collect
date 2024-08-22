using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnotherLinkage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Collection_CollectionId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CollectionId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Items",
                table: "Collection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Items",
                table: "Collection");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CollectionId",
                table: "Item",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Collection_CollectionId",
                table: "Item",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
