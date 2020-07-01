using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.Domain;
using Blog.EfDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CategoryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get(
            [FromQuery] CategorySearch search,
            [FromServices] IGetCategoryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id,
            [FromServices] IGetOneCategoryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }
        // POST: api/Category
        [HttpPost]
        public IActionResult Post(
            [FromBody] CategoryDto dto,
            [FromServices] ICreateCategoryCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
            [FromBody] CategoryDto dto,
            [FromServices] IEditCategoryCommand command)
        {
            dto.Id = id;

            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteCategoryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
