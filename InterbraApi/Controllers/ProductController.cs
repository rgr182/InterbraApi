using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InterbraApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRrepository)
        {
            _productRepository = productRrepository;
        }

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct()
        {
            return Ok();
        }

        [HttpGet("GetProducts")]
        public IActionResult SaveProduct(int amount)
        {
            return Ok(_productRepository.GetTopProducts(amount));
        }
    }
}




