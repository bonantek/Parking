using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class Next_Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("19f68dd9-1c40-4ed7-ad75-907cbe439e6d"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("8610eedc-aba0-4627-aac4-0fbcb88e7565"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("9f84db22-17fb-4674-b4d4-c2fd2c238b63"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("19f68dd9-1c40-4ed7-ad75-907cbe439e6d"), 150, "Krakow", "Parking dla kibicow Cracovii", "", "Parking B", "Reymonta", "2" },
                    { new Guid("8610eedc-aba0-4627-aac4-0fbcb88e7565"), 200, "Krakow", "Parking Wiselki", "", "Parking Wiselka", "Reymonta", "3" },
                    { new Guid("9f84db22-17fb-4674-b4d4-c2fd2c238b63"), 100, "Warszawa", "Big parking near Legia", "", "Parking A", "Lazienkowska", "1" }
                });
        }
    }
}
