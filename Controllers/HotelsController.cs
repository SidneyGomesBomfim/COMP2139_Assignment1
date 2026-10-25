using GBC_Travel.Data;
using GBC_Travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel.Controllers;

public class HotelsController : Controller
{
    private readonly ApplicationDbContext _context;

    public HotelsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Hotels  - the full list, by name.
    public async Task<IActionResult> Index()
    {
        var hotels = await _context.Hotels
            .AsNoTracking()
            .OrderBy(h => h.Name)
            .ToListAsync();

        return View(hotels);
    }

    // GET: /Hotels/Search?Location=Toronto&MinStars=3&Rooms=1
    public async Task<IActionResult> Search(HotelSearchViewModel model)
    {
        IQueryable<Models.Hotel> query = _context.Hotels.AsNoTracking();

        // Search parameters
        if (!string.IsNullOrWhiteSpace(model.Location))
        {
            var location = model.Location.Trim();
            query = query.Where(h => h.Location.Contains(location) || h.Name.Contains(location));
        }

        if (model.MinStars.HasValue)
        {
            query = query.Where(h => h.StarRating >= model.MinStars.Value);
        }

        var rooms = Math.Max(1, model.Rooms);
        model.Rooms = rooms;
        query = query.Where(h => h.RoomsAvailable >= rooms);

        // Filter: price range per night
        if (model.MinPrice.HasValue)
        {
            query = query.Where(h => h.PricePerNight >= model.MinPrice.Value);
        }

        if (model.MaxPrice.HasValue)
        {
            query = query.Where(h => h.PricePerNight <= model.MaxPrice.Value);
        }

        // Sort
        query = model.SortOrder switch
        {
            "price_desc" => query.OrderByDescending(h => h.PricePerNight),
            "rating" => query.OrderByDescending(h => h.StarRating).ThenBy(h => h.PricePerNight),
            "name" => query.OrderBy(h => h.Name),
            _ => query.OrderBy(h => h.PricePerNight)
        };

        model.Results = await query.ToListAsync();
        return View(model);
    }

    // GET: /Hotels/Details/3
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hotel = await _context.Hotels
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }
}
