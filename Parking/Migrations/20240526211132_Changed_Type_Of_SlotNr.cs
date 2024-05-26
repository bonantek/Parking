using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Type_Of_SlotNr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("9d7d3148-1170-42d9-8c00-fa1a8c2f3405"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("a414e0cc-482d-4791-9038-6ae6d2689fa1"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("dd02e24b-3c33-4c0d-824e-e183b75a85ed"));

            migrationBuilder.AlterColumn<int>(
                name: "SlotNr",
                table: "ParkingSlots",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("4368a67b-26cc-4349-a56b-74a4c6101dc8"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" },
                    { new Guid("6ab01c7a-e521-4f4e-9946-b3fd879f99e1"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("a0ec7f85-f795-428b-a516-77c35e808a7a"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("4368a67b-26cc-4349-a56b-74a4c6101dc8"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("6ab01c7a-e521-4f4e-9946-b3fd879f99e1"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("a0ec7f85-f795-428b-a516-77c35e808a7a"));

            migrationBuilder.AlterColumn<string>(
                name: "SlotNr",
                table: "ParkingSlots",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("9d7d3148-1170-42d9-8c00-fa1a8c2f3405"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" },
                    { new Guid("a414e0cc-482d-4791-9038-6ae6d2689fa1"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("dd02e24b-3c33-4c0d-824e-e183b75a85ed"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" }
                });
        }
    }
}
