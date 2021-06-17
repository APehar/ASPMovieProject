using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.MovieGenreDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.MovieGenreCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public MovieGenreController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<MovieGenreController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovieGenreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieGenreController>
        [HttpPost]
        public IActionResult Post([FromBody] AddMovieGenreDto dto, [FromServices] IAddMovieGenreCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MovieGenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieGenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMovieGenreCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
