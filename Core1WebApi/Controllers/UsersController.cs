using Core1WebApi.Models;
using CoreBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core1WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            ILogger<UsersController> logger,
            UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            if(user != null)
            {
                var createdGuid = _userService.AddUser(user);

                return Created(createdGuid.ToString(), user);
            }

            return BadRequest();
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var successed = _userService.UpdateUser(user);
            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(Guid id)
        {
            var user = _userService.RemoveUser(id);

            return StatusCode(user != null ? 200 : 404, user);
        }
    }
}
