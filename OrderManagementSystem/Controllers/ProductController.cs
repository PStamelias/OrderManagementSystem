using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }


        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            await _productService.AddProduct(productDTO);
            return Ok();
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await  _productService.GetProducts();
            return Ok(products);
        }
    }
}
