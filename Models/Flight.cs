using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBC_Travel.Models;

public class Flight
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The airline is required.")]
    [StringLength(60)]
    public string Airline { get; set; } = string.Empty;

    [Required(ErrorMessage = "The flight number is required.")]
    [StringLength(10)]
    [Display(Name = "Flight number")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "The origin is required.")]
    [StringLength(60)]
    public string Origin { get; set; } = string.Empty;

    [Required(ErrorMessage = "The destination is required.")]
    [StringLength(60)]
    public string Destination { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Departure")]
    public DateTime DepartureTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Arrival")]
    public DateTime ArrivalTime { get; set; }

    [Range(0.01, 100000, ErrorMessage = "The price must be greater than zero.")]
    [Column(TypeName = "decimal(10,2)")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Range(0, 1000, ErrorMessage = "Seats must be between 0 and 1000.")]
    [Display(Name = "Seats available")]
    public int SeatsAvailable { get; set; }

    [Range(0, 3, ErrorMessage = "Stops must be between 0 and 3.")]
    public int Stops { get; set; }

    // Optional: an image URL or path stored as a string (no file uploads).
    [StringLength(300)]
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    // Calculated in C#, not stored in the database.
    [NotMapped]
    public TimeSpan Duration => ArrivalTime - DepartureTime;

    [NotMapped]
    public string StopsText => Stops == 0 ? "Nonstop" : Stops == 1 ? "1 stop" : $"{Stops} stops";
}
