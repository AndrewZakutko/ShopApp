using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoryController : BaseApiController
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    [HttpPost("create/{categoryName}")]
    public ActionResult Create(string categoryName)
    {
        _categoryRepository.CreateCategory(categoryName);

        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        _categoryRepository.DeleteCategory(id);

        return Ok();
    }
}
