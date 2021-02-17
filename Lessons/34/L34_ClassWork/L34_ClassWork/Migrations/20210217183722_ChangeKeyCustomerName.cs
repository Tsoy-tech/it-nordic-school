using Microsoft.EntityFrameworkCore.Migrations;

namespace L34_ClassWork.Migrations
{
    public partial class ChangeKeyCustomerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UK_Customer_Name",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Name",
                schema: "dbo",
                table: "Customer",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Name",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_Customer_Name",
                schema: "dbo",
                table: "Customer",
                column: "Name");
        }
    }
}
