using Core1WebApi.Models;
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
        private static List<User> _users;
        private readonly ILogger<UsersController> _logger;

        static UsersController()
        {
            _users = new List<User>();
        }

        public UsersController(
            ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);

            return Created(user.Id.ToString(), user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            User user = _users.FirstOrDefault(user => user.Id == id);
            if(user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var dbUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if(dbUser != null)
            {
                // _users
                var index = _users.IndexOf(dbUser);
                _users[index] = user;

                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var dbUser = _users.FirstOrDefault(x => x.Id == id);

            if (dbUser != null)
            {
                _users.Remove(dbUser);

                return Ok(dbUser);
            }

            return NotFound();
        }
    }
}
