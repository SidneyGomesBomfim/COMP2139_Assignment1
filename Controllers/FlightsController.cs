using GBC_Travel.Data;
using GBC_Travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel.Controllers;

public class FlightsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FlightsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Flights  - the full list, soonest departure first.
    public async Task<IActionResult> Index()
    {
        var flights = await _context.Flights
            .AsNoTracking()
            .OrderBy(f => f.DepartureTime)
            .ToListAsync();

        return View(flights);
    }

    // GET: /Flights/Search?Origin=YYZ&Destination=YVR&DepartureDate=2026-11-02&Passengers=1
    // The query string is bound to the view model (model binding), then the
    // flights are filtered and sorted with LINQ. Nothing is saved, so GET is right.
    public async Task<IActionResult> Search(FlightSearchViewModel model)
    {
        IQueryable<Models.Flight> query = _context.Flights.AsNoTracking();

        // Search parameters
        if (!string.IsNullOrWhiteSpace(model.Origin))
        {
            var origin = model.Origin.Trim();
            query = query.Where(f => f.Origin.Contains(origin));
        }

        if (!string.IsNullOrWhiteSpace(model.Destination))
        {
            var destination = model.Destination.Trim();
            query = query.Where(f => f.Destination.Contains(destination));
        }

        if (model.DepartureDate.HasValue)
        {
            var day = model.DepartureDate.Value.Date;
            var nextDay = day.AddDays(1);
            query = query.Where(f => f.DepartureTime >= day && f.DepartureTime < nextDay);
        }

        // Enough seats for everyone travelling
        var passengers = Math.Max(1, model.Passengers);
        model.Passengers = passengers;
        query = query.Where(f => f.SeatsAvailable >= passengers);

        // Filter: price range
        if (model.MinPrice.HasValue)
        {
            query = query.Where(f => f.Price >= model.MinPrice.Value);
        }

        if (model.MaxPrice.HasValue)
        {
            query = query.Where(f => f.Price <= model.MaxPrice.Value);
        }

        // Sort
        query = model.SortOrder switch
        {
            "price_desc" => query.OrderByDescending(f => f.Price),
            "departure" => query.OrderBy(f => f.DepartureTime),
            _ => query.OrderBy(f => f.Price)
        };

        model.Results = await query.ToListAsync();
        return View(model);
    }

    // GET: /Flights/Details/3
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (flight == null)
        {
            return NotFound();   // an id that does not exist answers 404
        }

        return View(flight);
    }
}
