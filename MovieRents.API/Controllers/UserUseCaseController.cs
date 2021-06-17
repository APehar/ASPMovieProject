using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.UserUsecCaseDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.UserUseCaseCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UserUseCaseController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<UserUseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] UserUseCaseDto dto, [FromServices] ICreateUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<UserUseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
