using Tasman.Domain.API.Controllers;


namespace Tasman.Domain.API.Tests;

public class TaskTypesControllerTests
{
    [Fact]
    public async void TaskTypes_GetAllTasks_ShouldReturnActiveTasksForTheLoggedUser()
    {
        //Arrange
        var taskTypesController = new TaskTypesController();

        //Act
        var result = await taskTypesController.GetAllTasks();

        //Assert
        //TODO: finalizar!
        //Assert.True(result.)
    }
}