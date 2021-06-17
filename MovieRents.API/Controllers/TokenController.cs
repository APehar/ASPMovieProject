using Microsoft.AspNetCore.Mvc;
using MovieRents.API.Core;
using MovieRents.Application.Data_Transfer.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager manager;

        public TokenController(JwtManager manager)
        {
            this.manager = manager;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto dto)
        {
            var token = manager.MakeToken(dto.Username, dto.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token }); ;
        }
    }
}
