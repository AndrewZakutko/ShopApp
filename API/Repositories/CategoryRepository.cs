using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;
    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public void CreateCategory(string categoryName)
    {
        var category = new Category() { Name = categoryName };

        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if(category == null) return;

        _context.Remove(category);
        _context.SaveChanges();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();

        return categories;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        return category;
    }
}
