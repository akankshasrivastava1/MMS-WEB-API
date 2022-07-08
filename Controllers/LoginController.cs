using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using MMS.Data;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMS.Helpersb;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;
        public LoginController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.user.AsQueryable();
            return Ok(userdetails);
        }
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                userObj.Password = EncDscPassword.EncryptPassword(userObj.Password);
                _context.user.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Sign up Successfully"

                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.user.Where(a => a.UserName == userObj.UserName).FirstOrDefault();


                if (user != null && EncDscPassword.DecryptPassword(user.Password) == userObj.Password)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        UserType = user.UserType,
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
    }
}
