using System.Net;
using System.Text;
using System.Text.Json;
using EventStore.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasman.Domain.API.Data;
using Tasman.Domain.API.DTOs;
using Tasman.Domain.API.Models;
using Tasman.Shared.Library.Events;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Controllers;

[ApiController]
[Route("api/task-type")]
public class TaskTypeController(WriteDbContext writeDbContext/*, EventStoreClient eventStoreClient*/) : ControllerBase
{
    private WriteDbContext WriteDbContext { get; set; } = writeDbContext;
    // private EventStoreClient EventStoreClient { get; set; } = eventStoreClient;

    /// <summary>
    /// List all task types
    /// </summary>
    /// <response code="200">Returns all task types</response>
    /// <response code="500">An internal error occurred</response>
    [HttpGet("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<List<TaskType>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ListTasksTypes()
    {
        var tasks = await WriteDbContext.TaskTypes.ToListAsync();
        var response = new ApiResponse<List<TaskType>>(data: tasks);
        
        return Ok(response);
    }
    
    /// <summary>
    /// Update a task type
    /// </summary>
    /// <response code="202">Task type successfully udpated</response>
    /// <response code="400">There's a problem with the request</response>
    /// <response code="404">Task type was not found</response>
    /// <response code="500">An internal error occurred</response>
    [HttpPut("{taskTypeId:guid}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.Accepted)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateTaskType([FromRoute] Guid taskTypeId, [FromBody] UpdateTaskTypeRequest request)
    {
        if (taskTypeId == Guid.Empty)
            return BadRequest(new ApiResponse<object>());

        var taskType = await WriteDbContext.TaskTypes.FirstOrDefaultAsync(x => x.Id == taskTypeId);

        if (taskType is null)
            return NotFound(new ApiResponse<object>());

        taskType.Name = request.NewName;

        await WriteDbContext.SaveChangesAsync();

        var taskTypeNameUpdatedEvent = new TaskTypeUpdatedEvent
        {
            Id = taskType.Id,
            CreatedBy = taskType.CreatedBy,
            IsDeleted = taskType.IsDeleted,
            CreatedAt = taskType.CreatedAt,
            Name = taskType.Name
        };

        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(taskTypeNameUpdatedEvent);
        var eventData = new EventData(Uuid.NewUuid(), nameof(taskTypeNameUpdatedEvent), utf8Bytes.AsMemory());

        var settings = EventStoreClientSettings.Create("esdb+discover://localhost:2113?tls=false");
        var client = new EventStoreClient(settings);

        var writeResult = await client.AppendToStreamAsync(taskTypeNameUpdatedEvent.GetEventName(), StreamState.Any, new[] {eventData});
        
        var events = client.ReadStreamAsync(
            Direction.Forwards,
            taskTypeNameUpdatedEvent.GetEventName(),
            StreamPosition.Start);

        await foreach (var @event in events) 
        {
            Console.WriteLine(Encoding.UTF8.GetString(@event.Event.Data.ToArray()));
        }

        return Accepted(new ApiResponse<object>());
    }
    
    /// <summary>
    /// Delete a task type
    /// </summary>
    /// <response code="204">Task type successfully deleted</response>
    /// <response code="400">There's a problem with the request</response>
    /// <response code="404">Task type was not found</response>
    /// <response code="500">An internal error occurred</response>
    [HttpDelete("{taskTypeId:guid}")]
    [Consumes("application/json")]
    [Produces("application/json")] 
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteTaskType([FromRoute] Guid taskTypeId)
    {
        if (taskTypeId == Guid.Empty)
            return BadRequest(new ApiResponse<object>());

        var taskType = await WriteDbContext.TaskTypes.FirstOrDefaultAsync(x => x.Id == taskTypeId);

        if (taskType is null)
            return NotFound(new ApiResponse<object>());

        taskType.IsDeleted = true; //TODO: finish...

        await WriteDbContext.SaveChangesAsync();

        var taskTypeDeletedEvent = new TaskTypeDeletedEvent
        {
            Id = taskType.Id,
            CreatedBy = taskType.CreatedBy,
            IsDeleted = taskType.IsDeleted,
            CreatedAt = taskType.CreatedAt,
            Name = taskType.Name
        };

        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(taskTypeDeletedEvent);
        var eventData = new EventData(Uuid.NewUuid(), nameof(taskTypeDeletedEvent), utf8Bytes.AsMemory());

        var settings = EventStoreClientSettings.Create("esdb+discover://localhost:2113?tls=false");
        var client = new EventStoreClient(settings);

        await client.AppendToStreamAsync(taskTypeDeletedEvent.GetEventName(), StreamState.Any, new[] {eventData});
        
        return Accepted(new ApiResponse<object>());
    }
}