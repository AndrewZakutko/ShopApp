using System.ComponentModel.DataAnnotations;

namespace API.ViewModels;

public class ProductVM
{
    public string Category { get; set; }    
    public string Title { get; set; }
    public string Description { get; set; }
    public string? PhotoUrl { get; set; }
    public double Price { get; set; }
    public double? DiscountPrice { get; set; }
}
