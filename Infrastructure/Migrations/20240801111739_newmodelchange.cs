using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmodelchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_UserId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_Username",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Alerts",
                newName: "Username1");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_UserId",
                table: "Alerts",
                newName: "IX_Alerts_Username1");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_Username",
                table: "Alerts",
                column: "Username",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_Username1",
                table: "Alerts",
                column: "Username1",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_Username",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Customers_Username1",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "Username1",
                table: "Alerts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_Username1",
                table: "Alerts",
                newName: "IX_Alerts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_UserId",
                table: "Alerts",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Customers_Username",
                table: "Alerts",
                column: "Username",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
