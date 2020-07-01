using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public PostController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Post
        [HttpGet]
        public IActionResult Get(
            [FromQuery] PostSearch search,
            [FromServices] IGetPostsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult Get(int id,
            [FromServices] IGetOnePostQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Post(
            [FromBody] PostDto dto,
            [FromServices] ICreatePostCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
            [FromBody] PostDto dto,
            [FromServices] IEditPostCommand command)
        {
            dto.Id = id;

            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
