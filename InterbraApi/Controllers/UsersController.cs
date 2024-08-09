using Microsoft.AspNetCore.Mvc;
using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Repository;
using System.Collections.Generic;
using InterbraApi.Domain.Model;

namespace InterbraApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetUser")]
        public List<User> GetUser()
        {
            return _userRepository.GetUsers();
        }


        [HttpGet(Name = "GetShoppingCart")]
        public IEnumerable<ShoppingCartItemDTO> GetShoppingCart(int UserId)
        {
            return _userRepository.GetUserShoppingCart(UserId);
        }
    }
}
