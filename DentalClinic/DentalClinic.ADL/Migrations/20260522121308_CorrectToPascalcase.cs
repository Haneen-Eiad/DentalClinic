using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.ADL.Migrations
{
    /// <inheritdoc />
    public partial class CorrectToPascalcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sellerName",
                table: "Supplier",
                newName: "SellerName");

            migrationBuilder.RenameColumn(
                name: "appointmentType",
                table: "Appointment",
                newName: "AppointmentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellerName",
                table: "Supplier",
                newName: "sellerName");

            migrationBuilder.RenameColumn(
                name: "AppointmentType",
                table: "Appointment",
                newName: "appointmentType");
        }
    }
}
