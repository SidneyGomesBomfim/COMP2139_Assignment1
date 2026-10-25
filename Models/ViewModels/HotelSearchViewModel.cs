namespace GBC_Travel.Models.ViewModels;

public class HotelSearchViewModel
{
    // Search parameters (3)
    public string? Location { get; set; }
    public int? MinStars { get; set; }
    public int Rooms { get; set; } = 1;

    // Filter: price range per night
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    // Sort: price_asc (default), price_desc, rating, name
    public string? SortOrder { get; set; }

    public List<Hotel> Results { get; set; } = new();
}
