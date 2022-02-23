using Core1WebApi.Models;
using CoreBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Core1WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(
            UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(CoreDAL.Entities.Credentials credentials)
        {
            var token = await _userService.LoginAsync(credentials);

            return StatusCode(!string.IsNullOrEmpty(token) ? 200 : 401, token);
        }
    }
}
