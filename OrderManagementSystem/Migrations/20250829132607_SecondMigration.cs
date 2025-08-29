using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "Orders",
                newName: "ΤotalAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ΤotalAmount",
                table: "Orders",
                newName: "totalAmount");
        }
    }
}
