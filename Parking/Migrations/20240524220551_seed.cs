using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Capacity", "City", "Description", "Logo", "Name", "Street", "StreetNr" },
                values: new object[,]
                {
                    { new Guid("472cec39-7639-4903-9d1a-f03f38c93ced"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("697ef19f-b4cc-4572-8b76-27cd7821dd7e"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" },
                    { new Guid("d779316a-aa42-45ed-a4f0-b3ea3e1de3b0"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("472cec39-7639-4903-9d1a-f03f38c93ced"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("697ef19f-b4cc-4572-8b76-27cd7821dd7e"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("d779316a-aa42-45ed-a4f0-b3ea3e1de3b0"));
        }
    }
}
