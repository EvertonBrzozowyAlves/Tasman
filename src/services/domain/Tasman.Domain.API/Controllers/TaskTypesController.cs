using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Controllers;

[ApiController]
[Route("api/task-types")]
public class TaskTypesController : ControllerBase
{
    public TaskTypesController()
    {
    }

    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <response code="200">Returns the resource data</response>
    /// <response code="400">There is a problem with the request</response>
    /// <response code="500">An internal error occurred</response>
    [HttpGet("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllTasks()
    {
        return Ok(new ApiResponse<List<string>>());
    }
}