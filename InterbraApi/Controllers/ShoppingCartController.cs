using InterbraApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InterbraApi.Controllers
{
    public class ShoppingCartController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public ShoppingCartController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetShoppingCart")]
        public IActionResult GetShoppingCart(int UserId)
        {
            return Ok(_userRepository.GetUserShoppingCart(UserId));
        }
    }
}
