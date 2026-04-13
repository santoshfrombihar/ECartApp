using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECartApp.Migrations
{
    /// <inheritdoc />
    public partial class updateadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternateNumber",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "userAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternateNumber",
                table: "userAddresses");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "userAddresses");
        }
    }
}
