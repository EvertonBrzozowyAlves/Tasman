using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tasman.Shared.Library;

namespace TechBox.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    public TasksController()
    {
    }

    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <response code="200">Returns the resource data</response>
    /// <response code="500">An internal error occurred</response>
    [HttpGet("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllTasks()
    {
        //var storedFiles = await _taskRepository.ListFilesAsync();

        return Ok(new ApiResponse());
    }
}