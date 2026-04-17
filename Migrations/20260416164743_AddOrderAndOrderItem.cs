using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECartApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_products_ProductId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsColor_ColorId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_userAddresses_users_UserId",
                table: "userAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_users_UserId",
                table: "userProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userProfiles",
                table: "userProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAddresses",
                table: "userAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carts",
                table: "carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "userProfiles",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "userAddresses",
                newName: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "cartItems",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_userProfiles_UserId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userAddresses_UserId",
                table: "UserAddresses",
                newName: "IX_UserAddresses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_products_TypeId",
                table: "Products",
                newName: "IX_Products_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ColorId",
                table: "Products",
                newName: "IX_Products_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Users",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserProfiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserProfiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "UserAddresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "UserAddresses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "UserAddresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "UserAddresses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "UserAddresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateNumber",
                table: "UserAddresses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressType",
                table: "UserAddresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserAddresses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Products",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Carts",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CartItems",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GSTAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CouponDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Pending"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "UPI"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductColorId",
                table: "Products",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productsColor_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "productsColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productsColor_ProductColorId",
                table: "Products",
                column: "ProductColorId",
                principalTable: "productsColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productsType_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "productsType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productsType_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "productsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_productsColor_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_productsColor_ProductColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_productsType_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_productsType_TypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Price",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "userProfiles");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                newName: "userAddresses");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "carts");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "cartItems");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_UserId",
                table: "userProfiles",
                newName: "IX_userProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_UserId",
                table: "userAddresses",
                newName: "IX_userAddresses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeId",
                table: "products",
                newName: "IX_products_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ColorId",
                table: "products",
                newName: "IX_products_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "carts",
                newName: "IX_carts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "cartItems",
                newName: "IX_cartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "cartItems",
                newName: "IX_cartItems_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateNumber",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressType",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "cartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userProfiles",
                table: "userProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAddresses",
                table: "userAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carts",
                table: "carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_products_ProductId",
                table: "cartItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsColor_ColorId",
                table: "products",
                column: "ColorId",
                principalTable: "productsColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "products",
                column: "TypeId",
                principalTable: "productsType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userAddresses_users_UserId",
                table: "userAddresses",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_users_UserId",
                table: "userProfiles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
