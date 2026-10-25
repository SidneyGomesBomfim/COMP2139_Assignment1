using GBC_Travel.Models;

namespace GBC_Travel.Data;

// The seed data. EF Core inserts these rows when the migration is applied.
public static class SeedData
{
    public static Flight[] Flights() => new[]
    {
        new Flight { Id = 1, Airline = "Latam", FlightNumber = "LA808", Origin = "Toronto (YYZ)", Destination = "Salvador (SSA)",
            DepartureTime = new DateTime(2026, 11, 2, 8, 15, 0), ArrivalTime = new DateTime(2026, 11, 2, 18, 40, 0),
            Price = 850.00m, SeatsAvailable = 24, Stops = 1 },
        new Flight { Id = 2, Airline = "FlightSafe Airlines", FlightNumber = "FS705", Origin = "Toronto (YYZ)", Destination = "Miami (MIA)",
            DepartureTime = new DateTime(2026, 11, 2, 11, 30, 0), ArrivalTime = new DateTime(2026, 11, 2, 14, 45, 0),
            Price = 350.00m, SeatsAvailable = 12, Stops = 0 },
        new Flight { Id = 3, Airline = "Fly Away Airlines", FlightNumber = "FA511", Origin = "Vancouver (YVR)", Destination = "Ibiza (IBZ)",
            DepartureTime = new DateTime(2026, 11, 3, 14, 5, 0), ArrivalTime = new DateTime(2026, 11, 4, 12, 20, 0),
            Price = 920.00m, SeatsAvailable = 8, Stops = 2 },
        new Flight { Id = 4, Airline = "Brazil Airlines", FlightNumber = "BA131", Origin = "Montreal (YUL)", Destination = "Monaco (MCM)",
            DepartureTime = new DateTime(2026, 11, 2, 19, 45, 0), ArrivalTime = new DateTime(2026, 11, 3, 10, 10, 0),
            Price = 880.00m, SeatsAvailable = 30, Stops = 1 },
        new Flight { Id = 5, Airline = "GoGo Airlines", FlightNumber = "GG401", Origin = "Toronto (YYZ)", Destination = "Madeira (FNC)",
            DepartureTime = new DateTime(2026, 11, 4, 7, 0, 0), ArrivalTime = new DateTime(2026, 11, 4, 19, 25, 0),
            Price = 750.00m, SeatsAvailable = 40, Stops = 1 },
        new Flight { Id = 6, Airline = "Fly Away Airlines", FlightNumber = "FA318", Origin = "Toronto (YYZ)", Destination = "Montreal (YUL)",
            DepartureTime = new DateTime(2026, 11, 5, 9, 10, 0), ArrivalTime = new DateTime(2026, 11, 5, 10, 25, 0),
            Price = 150.00m, SeatsAvailable = 15, Stops = 0 },
        new Flight { Id = 7, Airline = "Latam", FlightNumber = "LA620", Origin = "Miami (MIA)", Destination = "Salvador (SSA)",
            DepartureTime = new DateTime(2026, 11, 5, 12, 20, 0), ArrivalTime = new DateTime(2026, 11, 5, 21, 35, 0),
            Price = 400.00m, SeatsAvailable = 6, Stops = 1 },
        new Flight { Id = 8, Airline = "FlightSafe Airlines", FlightNumber = "FS808", Origin = "Montreal (YUL)", Destination = "Miami (MIA)",
            DepartureTime = new DateTime(2026, 11, 6, 6, 45, 0), ArrivalTime = new DateTime(2026, 11, 6, 10, 30, 0),
            Price = 380.00m, SeatsAvailable = 5, Stops = 0 },
    };

    public static Hotel[] Hotels() => new[]
    {
        new Hotel { Id = 1, Name = "Fera Palace Hotel", Location = "Salvador", Address = "Rua Chile, 20 - Centro, Salvador - BA, Brazil",
            StarRating = 5, PricePerNight = 250.00m, RoomsAvailable = 12,
            Amenities = "Free Wi-Fi,Pool,Parking,Breakfast,Gym,Bar",
            Description = "A historic luxury hotel located in the heart of Salvador's historic center, overlooking the Bay of All Saints." },
        new Hotel { Id = 2, Name = "Ushuaïa Ibiza Beach Hotel", Location = "Ibiza", Address = "Ctra. de Platja d'en Bossa, 10, 07817 Sant Jordi, Spain",
            StarRating = 5, PricePerNight = 450.00m, RoomsAvailable = 5,
            Amenities = "Free Wi-Fi,Pool,Spa,Restaurant,Nightclub",
            Description = "The iconic hotel in Ibiza known for its world-famous pool parties and luxury beachfront experience." },
        new Hotel { Id = 3, Name = "Hôtel de Paris Monte-Carlo", Location = "Monaco", Address = "Place du Casino, 98000 Monaco",
            StarRating = 5, PricePerNight = 600.00m, RoomsAvailable = 20,
            Amenities = "Free Wi-Fi,Pool,Spa,Restaurant,Valet Parking",
            Description = "A legendary palace hotel offering ultimate luxury and elegance right in the center of Monte-Carlo." },
        new Hotel { Id = 4, Name = "Fontainebleau Miami Beach", Location = "Miami", Address = "4441 Collins Ave, Miami Beach, FL 33140, USA",
            StarRating = 5, PricePerNight = 320.00m, RoomsAvailable = 15,
            Amenities = "Free Wi-Fi,Pool,Spa,Beach Access,Gym,Restaurant",
            Description = "A classic Miami Beach resort featuring stunning ocean views, multiple pools, and vibrant nightlife." },
        new Hotel { Id = 5, Name = "Reid's Palace", Location = "Madeira", Address = "Estrada Monumental 139, 9000-098 Funchal, Portugal",
            StarRating = 5, PricePerNight = 380.00m, RoomsAvailable = 30,
            Amenities = "Free Wi-Fi,Pool,Spa,Gardens,Ocean View",
            Description = "A Belmond Hotel, this is one of the most famous and luxurious hotels in Madeira, perched high above the Atlantic Ocean." },
        new Hotel { Id = 6, Name = "Fairmont The Queen Elizabeth", Location = "Montreal", Address = "900 René-Lévesque Blvd W, Montreal, Quebec H3B 4A5",
            StarRating = 4, PricePerNight = 220.00m, RoomsAvailable = 25,
            Amenities = "Free Wi-Fi,Indoor Pool,Gym,Restaurant,Bar",
            Description = "A modern hotel in the heart of downtown Montreal, directly connected to the underground city." },
    };
}