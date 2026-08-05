using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStockItmsandRelationsWithPRoductandWorkHousess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "WorkHouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId1",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkHouseId1",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_ProductsId1",
                table: "StockItems",
                column: "ProductsId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_WorkHouseId1",
                table: "StockItems",
                column: "WorkHouseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Products_ProductsId1",
                table: "StockItems",
                column: "ProductsId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_WorkHouses_WorkHouseId1",
                table: "StockItems",
                column: "WorkHouseId1",
                principalTable: "WorkHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Products_ProductsId1",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_WorkHouses_WorkHouseId1",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_ProductsId1",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_WorkHouseId1",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "WorkHouses");

            migrationBuilder.DropColumn(
                name: "ProductsId1",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "WorkHouseId1",
                table: "StockItems");
        }
    }
}
