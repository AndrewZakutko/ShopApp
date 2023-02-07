using API.Models;

namespace API.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int Id);
    void CreateCategory(string categoryName);  
    void DeleteCategory(int id);
}
