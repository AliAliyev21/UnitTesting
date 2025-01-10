using Microsoft.AspNetCore.Mvc;
using UnitTesting.Entities;
using UnitTesting.Services;

namespace UnitTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] int top = 0)
        {
            var products = _productService.GetProducts(top);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProduct = _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid || id != product.Id)
                return BadRequest(ModelState);

            var updatedProduct = _productService.Update(product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
