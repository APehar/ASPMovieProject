using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.UserCommands;
using MovieRents.Application.IQueries.UserQueries;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UserController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto dto, [FromServices] ICreateUserCommand command)
        {
                _executor.ExecuteCommand(command, dto);
                return StatusCode(201);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserDto dto, [FromServices] IEditUserCommand command)
        {
                dto.Id = id;
                _executor.ExecuteCommand(command, dto);
                return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
                _executor.ExecuteCommand(command, id);
                return NoContent();
        }
    }
}
