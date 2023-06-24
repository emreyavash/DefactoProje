using Business.Interface;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefactoProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("Products")]
        public IActionResult GetProductsAll() 
        {
           var result= _productRepository.GetProductsAll();
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("Product")]
        public IActionResult GetProductById(int id)
        {
            var result = _productRepository.GetProductById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
             _productRepository.AddProduct(product);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
           _productRepository.UpdateProduct(product);
           
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
