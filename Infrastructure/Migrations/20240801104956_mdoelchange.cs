using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mdoelchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_UserTo",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "UserTo",
                table: "Alerts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_UserTo",
                table: "Alerts",
                newName: "IX_Alerts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_UserId",
                table: "Alerts",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_UserId",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Alerts",
                newName: "UserTo");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_UserId",
                table: "Alerts",
                newName: "IX_Alerts_UserTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_UserTo",
                table: "Alerts",
                column: "UserTo",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
