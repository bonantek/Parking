using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class add_newList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("4368a67b-26cc-4349-a56b-74a4c6101dc8"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" },
                    { new Guid("6ab01c7a-e521-4f4e-9946-b3fd879f99e1"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("a0ec7f85-f795-428b-a516-77c35e808a7a"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" }
                });
        }
    }
}
