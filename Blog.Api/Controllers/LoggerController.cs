using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LoggerController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Logger
        [HttpGet]
        public IActionResult Get(
            [FromQuery] LogSearch search,
            [FromServices] IGetLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
