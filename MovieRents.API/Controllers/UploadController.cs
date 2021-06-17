using Microsoft.AspNetCore.Mvc;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.MovieCommands;
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
    public class UploadController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UploadController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadPosterDto dto, [FromServices] IUploadMoviePosterCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UploadPosterDto dto, [FromServices] IUploadMoviePosterCommand command)
        {
            dto.MovieId = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
    }
}
