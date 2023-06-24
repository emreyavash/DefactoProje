using Business.Interface;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefactoProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("Categories")]
        public IActionResult GetCategoriesAll() 
        {
            var result = _categoryRepository.GetCategoriesAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Category")]
        public IActionResult GetCategoryById(int id)
        { 
            var result = _categoryRepository.GetCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category) 
        {
            _categoryRepository.AddCategory(category);
            return Ok("Başarılı şekilde eklendi.");
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            return Ok("Başarılı şekilde güncellendi");
        }
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(Category category)
        {
            _categoryRepository.DeleteCategory(category);
            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
