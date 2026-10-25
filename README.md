# GBC_Travel – COMP 2139, Assignment 1

Travel booking site (browse side): search flights and hotels, filter, sort and view details.
Built with ASP.NET Core MVC, C#, MVC design and Entity Framework Core (with migrations).

## Before you run it (once)

1. Install the **.NET 8 SDK** and **SQL Server LocalDB** (it comes with Visual Studio's *ASP.NET and web development* workload).
2. Open `appsettings.json` and fill in the **Team** section: `GroupNumber` and the `Members` names. The footer reads them from there.
3. Rename the folder / repository to `GBC_Travel-Group-<Number>` (your real group number).

> If your computer has a different .NET version, change `<TargetFramework>` in `GBC_Travel.csproj`
> (for example `net9.0`) and the two `Microsoft.EntityFrameworkCore.*` package versions to the same major number.

## Create the migration (compulsory – do it once, then commit the Migrations folder)

```bash
dotnet tool install --global dotnet-ef --version 8.0.11
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

In Visual Studio (Package Manager Console): `Add-Migration InitialCreate` then `Update-Database`.

This creates the `Migrations` folder. **Commit it.** The app also calls `Database.Migrate()` at startup,
so a fresh clone builds its own database and loads the seed data the first time it runs.

## Run

```bash
dotnet run
```

Open `https://localhost:5001`.

## What is where

| Folder / file | Purpose |
|---|---|
| `Models/Flight.cs`, `Models/Hotel.cs` | Entities with data annotations |
| `Models/ViewModels/` | Search form values + results, home page deals |
| `Data/ApplicationDbContext.cs` | DbContext, `DbSet<Flight>`, `DbSet<Hotel>`, seeding |
| `Data/SeedData.cs` | 8 flights and 6 hotels |
| `Controllers/` | `Home`, `Flights`, `Hotels` (Index, Search, Details) |
| `Views/Shared/_Layout.cshtml` | Shared layout: navbar and footer |
| `Views/Shared/_FlightCard.cshtml`, `_HotelCard.cshtml` | Result cards (partial views) |
| `wwwroot/js/site.js` | Auto-submit sort, price range check, back link |
| `docs/ERD.png` | Class diagram / ERD for the video |

## Pages and URLs

| Page | URL |
|---|---|
| Home (search tabs + featured deals) | `/` |
| All flights / flight search / details | `/Flights`, `/Flights/Search`, `/Flights/Details/1` |
| All hotels / hotel search / details | `/Hotels`, `/Hotels/Search`, `/Hotels/Details/1` |

## Try these searches (seed data)

- Flights: From `YYZ`, To `YVR`, date `2026-11-02` → 4 flights.
- Flights: From `Paris` → no results message.
- Hotels: Location `Toronto` → 2 hotels. Minimum stars 5 + rooms 3 → Maple Leaf Lodge only.
- Details with a missing id: `/Hotels/Details/999` → 404.

## Not part of Assignment 1

Car rentals, booking, create/edit/delete and user accounts (Assignment 2).
