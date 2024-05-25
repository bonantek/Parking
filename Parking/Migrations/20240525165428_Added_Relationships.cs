using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class Added_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("07020532-7842-4f7f-9bd5-982af604b5fa"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("0a1b53d7-8e13-4689-9e20-ce46fc7ff7a7"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("175914dd-0287-4ce7-bd8c-65fa167bb743"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("07020532-7842-4f7f-9bd5-982af604b5fa"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" },
                    { new Guid("0a1b53d7-8e13-4689-9e20-ce46fc7ff7a7"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("175914dd-0287-4ce7-bd8c-65fa167bb743"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" }
                });
        }
    }
}
