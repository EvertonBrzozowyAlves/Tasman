using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tasman.Domain.API.Models;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Controllers;

[ApiController]
[Route("api/task-types")]
public class TaskTypesController : ControllerBase
{
    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <response code="200">Returns the resource data</response>
    /// <response code="500">An internal error occurred</response>
    [HttpGet("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<List<TaskType>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllTasks()
    {
        //var teste = string.Empty;
        return Ok(new ApiResponse<List<TaskType>>());
    }
}