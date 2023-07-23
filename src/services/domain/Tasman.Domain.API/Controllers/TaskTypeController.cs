using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tasman.Shared.Library;

namespace TechBox.Api.Controllers;

[ApiController]
[Route("api/task-types")]
public class TaskTypesController : ControllerBase
{
    public TaskTypesController()
    {
    }
}