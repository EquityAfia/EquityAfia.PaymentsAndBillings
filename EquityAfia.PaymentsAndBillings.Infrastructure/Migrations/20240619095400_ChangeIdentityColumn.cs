using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Drop the existing column
            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "Payments");

            // Recreate the column with new identity settings
            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1"); // Add identity specific

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "BillingId",
           table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

        }
    }
}
