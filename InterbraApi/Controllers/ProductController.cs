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
    }
}




