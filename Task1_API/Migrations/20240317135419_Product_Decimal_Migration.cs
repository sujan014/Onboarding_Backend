using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1_API.Migrations
{
    /// <inheritdoc />
    public partial class Product_Decimal_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_Customers_CustomerId",
                table: "sales");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_Products_ProductId",
                table: "sales");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_Stores_StoreId",
                table: "sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sales",
                table: "sales");

            migrationBuilder.RenameTable(
                name: "sales",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_sales_StoreId",
                table: "Sales",
                newName: "IX_Sales_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_sales_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_sales_CustomerId",
                table: "Sales",
                newName: "IX_Sales_CustomerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Stores_StoreId",
                table: "Sales",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Stores_StoreId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "sales");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_StoreId",
                table: "sales",
                newName: "IX_sales_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "sales",
                newName: "IX_sales_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerId",
                table: "sales",
                newName: "IX_sales_CustomerId");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sales",
                table: "sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_Customers_CustomerId",
                table: "sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_Products_ProductId",
                table: "sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_Stores_StoreId",
                table: "sales",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
