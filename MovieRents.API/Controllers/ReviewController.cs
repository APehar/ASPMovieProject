using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.ReviewCommands;
using MovieRents.Application.IQueries.ReviewQueries;
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
    public class ReviewController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ReviewController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get([FromQuery] ReviewSearch search, [FromServices] IGetReviewsQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneReviewQuery query)
        {
                return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDto dto, [FromServices] ICreateReviewCommand command)
        {
                _executor.ExecuteCommand(command, dto);
                return StatusCode(201);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditReviewDto dto, [FromServices] IEditReviewCommand command)
        {
                dto.Id = id;
                _executor.ExecuteCommand(command, dto);
                return NoContent();
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReviewCommand command)
        {
                _executor.ExecuteCommand(command, id);
                return NoContent();
        }
    }
}
