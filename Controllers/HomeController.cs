using System.Diagnostics;
using GBC_Travel.Data;
using GBC_Travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Home page: search tabs plus a few featured listings taken from the seed data.
    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel();

        var hotels = await _context.Hotels
            .AsNoTracking()
            .OrderByDescending(h => h.StarRating)
            .ThenBy(h => h.PricePerNight)
            .Take(2)
            .ToListAsync();

        var flight = await _context.Flights
            .AsNoTracking()
            .Where(f => f.SeatsAvailable > 0)
            .OrderBy(f => f.Price)
            .FirstOrDefaultAsync();

        if (hotels.Count > 0)
        {
            model.Deals.Add(ToDeal(hotels[0]));
        }

        if (flight != null)
        {
            model.Deals.Add(new FeaturedDeal
            {
                Title = $"{flight.Origin} → {flight.Destination}",
                Subtitle = $"{flight.Airline} · {flight.StopsText}",
                PriceText = $"From {flight.Price:C0}",
                Controller = "Flights",
                Id = flight.Id,
                Icon = "✈"
            });
        }

        if (hotels.Count > 1)
        {
            model.Deals.Add(ToDeal(hotels[1]));
        }

        return View(model);
    }

    private static FeaturedDeal ToDeal(Models.Hotel hotel) => new()
    {
        Title = hotel.Name,
        Subtitle = $"{hotel.Location} · {hotel.StarsText}",
        PriceText = $"{hotel.PricePerNight:C0} / night",
        Controller = "Hotels",
        Id = hotel.Id,
        Icon = "🏨"
    };

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        return View();
    }
}
