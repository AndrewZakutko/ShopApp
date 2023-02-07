using API.Models;
using API.ViewModels;

namespace API.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int Id);
    void CreateProduct(ProductVM productVM);  
    void DeleteProduct(int id);
}
