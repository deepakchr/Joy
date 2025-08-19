using AdfsaLabAPI.Models;
using AdfsaLabAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdfsaLabAPI.Controllers
{
    public class AuthController : ApiController
    {
        private UserService _userService = new UserService();

        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] Users request)
        {
            
            string sPassword = request.UserPass; 

            var userId = _userService.ValidateUser(request.Username, sPassword);
            if (userId.HasValue)
            {
                var apiKey = _userService.CreateApiKey(userId.Value, 60); // expires in 60 mins
                return Ok(new { ApiKey = apiKey, ExpiresInMinutes = 60 });
            }

            return Unauthorized();
        }
    }
}
