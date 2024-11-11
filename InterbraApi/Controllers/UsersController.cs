using Microsoft.AspNetCore.Mvc;
using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Repository;

namespace InterbraApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetUser")]
        public List<User> GetUser()
        {
            return _userRepository.GetUsers();
        }


      
        [HttpPost(Name = "SaveUser")]
        public User SaveUser(User user)
        {
            return _userRepository.SaveUser(user);
        }
    }
}
