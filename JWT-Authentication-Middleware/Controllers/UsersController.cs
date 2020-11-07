using JWT_Authentication_Middleware.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace JWT_Authentication_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
