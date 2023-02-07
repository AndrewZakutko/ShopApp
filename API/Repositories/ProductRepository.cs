using API.Data;
using API.Interfaces;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public void CreateProduct(ProductVM productVM)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Name == productVM.Category);
        if(category == null) return;
        var product = new Product()
        {
            Category = category,
            Title = productVM.Title,
            Description = productVM.Description,
            PhotoUrl = productVM.PhotoUrl,
            Price = productVM.Price,
            DiscountPrice = productVM.DiscountPrice
        };
        _context.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if(product == null) return;
        _context.SaveChanges();
    }

    public async Task<Product> GetProductByIdAsync(int Id)
    {
        var product = await _context.Products.FindAsync(Id);
        return product;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await _context.Products.Include(x => x.Category).ToListAsync();
        return products;
    }
}
