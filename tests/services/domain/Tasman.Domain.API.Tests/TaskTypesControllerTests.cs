using Tasman.Domain.API.Controllers;

namespace Tasman.Domain.API.Tests;

public class TaskTypesControllerTests
{
    [Fact]
    public async void TaskTypes_GetAllTasks_ShouldReturnActiveTasksForTheLoggedUser()
    {
        //Arrange
        TaskTypesController taskTypesController = new();

        //Act
        Microsoft.AspNetCore.Mvc.IActionResult result = await taskTypesController.GetAllTasks();

        //Assert
        //TODO: finalizar!
        //Assert.True(result.)
    }
}