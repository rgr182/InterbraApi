using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InterbraApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        // Constructor initializes the ProductController with an instance of IProductRepository
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Method created for saving products. This may include bras and panties from Interbra.
        /// </summary>
        /// <param name="newproduct">Represents the model created for Interbra underwear products</param>
        /// <returns>Returns an accurate status code based on the success or failure of the request</returns>
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct([FromBody] Product newproduct)
        {
            return Ok(_productRepository.SaveProduct(newproduct));
        }

        /// <summary>
        /// Retrieves a specific number of products.
        /// </summary>
        /// <param name="amount">The number of products to retrieve</param>
        /// <returns>Returns the top products based on the specified amount</returns>
        [HttpGet("GetProducts")]
        public IActionResult GetProducts(int amount)
        {
            return Ok(_productRepository.GetTopProducts(amount));
        }
    }
}
