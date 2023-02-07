using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public Category Category { get; set; }    
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public string? PhotoUrl { get; set; }
    [Required]
    public double Price { get; set; }
    public double? DiscountPrice { get; set; }
    public bool isAvailable { get; set; } = true;
    public DateTime CreadtedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdated { get; set; }
}
