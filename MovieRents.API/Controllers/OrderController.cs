using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.OrderCommands;
using MovieRents.Application.IQueries.OrderQueries;
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
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public OrderController(CinemaContext context, UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
