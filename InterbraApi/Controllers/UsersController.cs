using Microsoft.AspNetCore.Mvc;

namespace InterbraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
      
      
        [HttpGet(Name = "GetUsers")]
        public string Get()
        {
            return "Mauricio";
        }
    }
}
