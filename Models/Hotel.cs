using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBC_Travel.Models;

public class Hotel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The hotel name is required.")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The city is required.")]
    [StringLength(80)]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "The address is required.")]
    [StringLength(150)]
    public string Address { get; set; } = string.Empty;

    [Range(1, 5, ErrorMessage = "The star rating must be from 1 to 5.")]
    [Display(Name = "Star rating")]
    public int StarRating { get; set; }

    [Range(0.01, 100000, ErrorMessage = "The price must be greater than zero.")]
    [Column(TypeName = "decimal(10,2)")]
    [DataType(DataType.Currency)]
    [Display(Name = "Price per night")]
    public decimal PricePerNight { get; set; }

    [Range(0, 1000, ErrorMessage = "Rooms must be between 0 and 1000.")]
    [Display(Name = "Rooms available")]
    public int RoomsAvailable { get; set; }

    // Comma-separated list, for example: "Free Wi-Fi,Pool,Parking".
    [StringLength(300)]
    public string Amenities { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    // Optional: an image URL or path stored as a string (no file uploads).
    [StringLength(300)]
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [NotMapped]
    public string[] AmenityList =>
        Amenities.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    [NotMapped]
    public string StarsText
    {
        get
        {
            var stars = Math.Clamp(StarRating, 0, 5);
            return new string('★', stars) + new string('☆', 5 - stars);
        }
    }
}
