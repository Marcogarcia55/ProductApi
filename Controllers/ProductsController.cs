using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            await _productService.AddAsync(product);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            await _productService.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
