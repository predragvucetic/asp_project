using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CommentController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Comment
        [HttpGet]
        public IActionResult Get(
            [FromQuery] CommentSearch search,
            [FromServices] IGetCommentsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult Get(int id,
            [FromServices] IGetOneCommentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post(
            [FromBody] CommentDto dto,
            [FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
            [FromBody] CommentDto dto,
            [FromServices] IEditCommentCommand command)
        {
            dto.Id = id;
            
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
