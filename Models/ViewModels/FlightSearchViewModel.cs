namespace GBC_Travel.Models.ViewModels;

// Carries the search form values (so they stay visible on the results page)
// together with the flights that matched.
public class FlightSearchViewModel
{
    // Search parameters (3)
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime? DepartureDate { get; set; }
    public int Passengers { get; set; } = 1;

    // Filter: price range
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    // Sort: price_asc (default), price_desc, departure
    public string? SortOrder { get; set; }

    public List<Flight> Results { get; set; } = new();
}
