namespace GBC_Travel.Models.ViewModels;

public class HomeViewModel
{
    public List<FeaturedDeal> Deals { get; set; } = new();
}

public class FeaturedDeal
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string PriceText { get; set; } = string.Empty;

    // "Flights" or "Hotels" (the controller that shows the details page)
    public string Controller { get; set; } = string.Empty;
    public int Id { get; set; }
    public string Icon { get; set; } = string.Empty;
}
