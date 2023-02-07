using API.Interfaces;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _productRepository.GetProductsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }

    [HttpPost("create")]
    public ActionResult Create(ProductVM product)
    {
        _productRepository.CreateProduct(product);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        _productRepository.DeleteProduct(id);
        return Ok();
    }
}
