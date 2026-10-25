using System.Globalization;
using GBC_Travel.Data;
using Microsoft.EntityFrameworkCore;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-CA");



CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-CA");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-CA");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// AQUI FOI ALTERADO: UseNpgsql em vez de UseSqlServer
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Creates the database from the EF Core migrations (and loads the seed data)
// the first time the application runs, so a fresh clone works on its own.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
