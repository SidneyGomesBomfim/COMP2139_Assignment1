using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GBC_Travel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Airline = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    FlightNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Origin = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Destination = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    SeatsAvailable = table.Column<int>(type: "integer", nullable: false),
                    Stops = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    StarRating = table.Column<int>(type: "integer", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    RoomsAvailable = table.Column<int>(type: "integer", nullable: false),
                    Amenities = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airline", "ArrivalTime", "DepartureTime", "Destination", "FlightNumber", "ImageUrl", "Origin", "Price", "SeatsAvailable", "Stops" },
                values: new object[,]
                {
                    { 1, "Latam", new DateTime(2026, 11, 2, 18, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 2, 8, 15, 0, 0, DateTimeKind.Unspecified), "Salvador (SSA)", "LA808", null, "Toronto (YYZ)", 850.00m, 24, 1 },
                    { 2, "FlightSafe Airlines", new DateTime(2026, 11, 2, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), "Miami (MIA)", "FS705", null, "Toronto (YYZ)", 350.00m, 12, 0 },
                    { 3, "Fly Away Airlines", new DateTime(2026, 11, 4, 12, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 3, 14, 5, 0, 0, DateTimeKind.Unspecified), "Ibiza (IBZ)", "FA511", null, "Vancouver (YVR)", 920.00m, 8, 2 },
                    { 4, "Brazil Airlines", new DateTime(2026, 11, 3, 10, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 2, 19, 45, 0, 0, DateTimeKind.Unspecified), "Monaco (MCM)", "BA131", null, "Montreal (YUL)", 880.00m, 30, 1 },
                    { 5, "GoGo Airlines", new DateTime(2026, 11, 4, 19, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), "Madeira (FNC)", "GG401", null, "Toronto (YYZ)", 750.00m, 40, 1 },
                    { 6, "Fly Away Airlines", new DateTime(2026, 11, 5, 10, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 5, 9, 10, 0, 0, DateTimeKind.Unspecified), "Montreal (YUL)", "FA318", null, "Toronto (YYZ)", 150.00m, 15, 0 },
                    { 7, "Latam", new DateTime(2026, 11, 5, 21, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 5, 12, 20, 0, 0, DateTimeKind.Unspecified), "Salvador (SSA)", "LA620", null, "Miami (MIA)", 400.00m, 6, 1 },
                    { 8, "FlightSafe Airlines", new DateTime(2026, 11, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 6, 6, 45, 0, 0, DateTimeKind.Unspecified), "Miami (MIA)", "FS808", null, "Montreal (YUL)", 380.00m, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Amenities", "Description", "ImageUrl", "Location", "Name", "PricePerNight", "RoomsAvailable", "StarRating" },
                values: new object[,]
                {
                    { 1, "Rua Chile, 20 - Centro, Salvador - BA, Brazil", "Free Wi-Fi,Pool,Parking,Breakfast,Gym,Bar", "A historic luxury hotel located in the heart of Salvador's historic center, overlooking the Bay of All Saints.", null, "Salvador", "Fera Palace Hotel", 250.00m, 12, 5 },
                    { 2, "Ctra. de Platja d'en Bossa, 10, 07817 Sant Jordi, Spain", "Free Wi-Fi,Pool,Spa,Restaurant,Nightclub", "The iconic hotel in Ibiza known for its world-famous pool parties and luxury beachfront experience.", null, "Ibiza", "Ushuaïa Ibiza Beach Hotel", 450.00m, 5, 5 },
                    { 3, "Place du Casino, 98000 Monaco", "Free Wi-Fi,Pool,Spa,Restaurant,Valet Parking", "A legendary palace hotel offering ultimate luxury and elegance right in the center of Monte-Carlo.", null, "Monaco", "Hôtel de Paris Monte-Carlo", 600.00m, 20, 5 },
                    { 4, "4441 Collins Ave, Miami Beach, FL 33140, USA", "Free Wi-Fi,Pool,Spa,Beach Access,Gym,Restaurant", "A classic Miami Beach resort featuring stunning ocean views, multiple pools, and vibrant nightlife.", null, "Miami", "Fontainebleau Miami Beach", 320.00m, 15, 5 },
                    { 5, "Estrada Monumental 139, 9000-098 Funchal, Portugal", "Free Wi-Fi,Pool,Spa,Gardens,Ocean View", "A Belmond Hotel, this is one of the most famous and luxurious hotels in Madeira, perched high above the Atlantic Ocean.", null, "Madeira", "Reid's Palace", 380.00m, 30, 5 },
                    { 6, "900 René-Lévesque Blvd W, Montreal, Quebec H3B 4A5", "Free Wi-Fi,Indoor Pool,Gym,Restaurant,Bar", "A modern hotel in the heart of downtown Montreal, directly connected to the underground city.", null, "Montreal", "Fairmont The Queen Elizabeth", 220.00m, 25, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
