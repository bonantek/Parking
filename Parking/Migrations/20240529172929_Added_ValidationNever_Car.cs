using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class Added_ValidationNever_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("287d3982-87db-4845-8ccb-f18f9cfd6ec4"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("28c39407-e683-4588-9406-1b5af23f5e24"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("439fb5c3-92cc-412e-85f3-de51220a7dc5"));

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("52d57c08-e301-47ec-a461-8e74922eab3a"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" },
                    { new Guid("899ae007-55ac-47f8-9e09-62698994275a"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("aaee3114-c17b-4d19-bc18-a71791956a1b"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("52d57c08-e301-47ec-a461-8e74922eab3a"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("899ae007-55ac-47f8-9e09-62698994275a"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("aaee3114-c17b-4d19-bc18-a71791956a1b"));

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("287d3982-87db-4845-8ccb-f18f9cfd6ec4"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("28c39407-e683-4588-9406-1b5af23f5e24"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" },
                    { new Guid("439fb5c3-92cc-412e-85f3-de51220a7dc5"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" }
                });
        }
    }
}
