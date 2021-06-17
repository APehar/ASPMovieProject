using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.Application.IQueries.MovieQueries;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public MovieController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search, [FromServices] IGetMoviesQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneMovieQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto dto, [FromServices] ICreateMovieCommand command)
        {
            _executor.ExecuteCommand(command, dto);
                return StatusCode(201);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditMovieDto dto, [FromServices] IEditMovieCommand command)
        {
                dto.Id = id;
                _executor.ExecuteCommand(command, dto);
                return NoContent();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMovieCommand command)
        {
                _executor.ExecuteCommand(command, id);
                return NoContent();
        }
    }
}
