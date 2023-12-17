using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Controllers;

[ApiController]
[Route("api/task")]
public class TaskController : ControllerBase
{
    ///<summary>
    /// Get all tasks
    /// </summary>
    ///<response code="200">Returns the resource data</response>
    ///<response code="500">An internal error occurred</response>
    [HttpGet("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<List<Models.Task>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
    public IActionResult GetAllTasks()
    {
        return Ok(new ApiResponse<List<Models.Task>>());
    }
}