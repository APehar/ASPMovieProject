using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.GenreCommands;
using MovieRents.Application.IQueries.GenreQueries;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GenreController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get([FromQuery] GenreSearch search, [FromServices] IGetGenresQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneGenreQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto dto, [FromServices] ICreateGenreCommand command)
        {
                _executor.ExecuteCommand(command, dto);
                return StatusCode(201);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditGenreDto dto, [FromServices] IEditGenreCommand command)
        {
                dto.Id = id;
                _executor.ExecuteCommand(command, dto);
                return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenreCommand command)
        {
                _executor.ExecuteCommand(command, id);
                return NoContent();
        }
    }
}
