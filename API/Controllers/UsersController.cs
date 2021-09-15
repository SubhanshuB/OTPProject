using GrowIndigo_Otp_Login_DemoProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowIndigo_Otp_Login_DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userService.Get();
            return Ok(result);

        }

        // GET api/<UsersController>/5
        [HttpGet("{phoneNumber}")]
        public IActionResult Get(string phoneNumber)
        {
            User userObj = _userService.Get(phoneNumber);

            return Ok(userObj);
            
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                User userobj = _userService.Create(user);
                if (userobj == null)
                    return Conflict("Phone number already exists.");
            }
            else
                return BadRequest("Invalid Model");

            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{phoneNumber}")]
        public void Delete(string phoneNumber)
        {
            _userService.Remove(phoneNumber);
        }
    }
}
