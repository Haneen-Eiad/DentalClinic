using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.ADL.Migrations
{
    /// <inheritdoc />
    public partial class Audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Treatment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Treatment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Treatment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Supplier",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PrescriptionItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PrescriptionItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PrescriptionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Prescription",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PatientTreatment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PatientTreatment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PatientTreatment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Medicine",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Expenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EquipmentCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EquipmentCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "EquipmentCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Equipment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Appointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PrescriptionItem");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PrescriptionItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PrescriptionItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PatientTreatment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EquipmentCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EquipmentCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EquipmentCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Appointment");
        }
    }
}
