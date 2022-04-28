using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLabelWebshopS3.Migrations
{
    public partial class OrderEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_CustomerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_shippingAddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_UserCustomerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "shippingAddressId",
                table: "Order",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserCustomerId",
                table: "Order",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserCustomerId",
                table: "Order",
                newName: "IX_Order_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_shippingAddressId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customer",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_Id",
                table: "Customer",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_Id",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Order",
                newName: "shippingAddressId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Order",
                newName: "UserCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                newName: "IX_Order_shippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                newName: "IX_Order_UserCustomerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customer",
                newName: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_CustomerId",
                table: "Customer",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_shippingAddressId",
                table: "Order",
                column: "shippingAddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_UserCustomerId",
                table: "Order",
                column: "UserCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");
        }
    }
}
