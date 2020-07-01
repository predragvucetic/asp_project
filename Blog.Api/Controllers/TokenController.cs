using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Api.Core;
using Blog.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _manager;

        public TokenController(JwtManager manager)
        {
            _manager = manager;
        }

        // POST: api/Token
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            var token = _manager.MakeToken(request.Username, request.Password);

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
