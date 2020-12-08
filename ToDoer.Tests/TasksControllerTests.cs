using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoer.Api.Controllers;
using ToDoer.Api.Services;
using Moq;
using ToDoer.Api.Models;
using ToDoer.Api.Validation;

namespace ToDoer.Tests
{
    [TestFixture]
    public class TasksControllerTests
    {
        [Test]
        public void WhenPostTaskAndValidationOk_ThenCallTasksService()
        {
            var tasksServiceMock = new Mock<ITaskService>();
            var tasksValidatorMock = new Mock<ITasksValidator>();
            var target = new TasksController(tasksServiceMock.Object, tasksValidatorMock.Object);
            
            target.Post(new Task());
            
            tasksServiceMock.Verify(x => x.Insert(It.IsAny<Task>()), Times.Once);
        }
        
        [Test]
        public void WhenPostTaskAndValidationFailed_ThenReturnBadRequest()
        {
            var tasksServiceMock = new Mock<ITaskService>();
            var tasksValidatorMock = new Mock<ITasksValidator>();
            tasksValidatorMock.Setup(x => x.Validate(It.IsAny<Task>())).Throws<TasksValidatorException>();
            var target = new TasksController(tasksServiceMock.Object, tasksValidatorMock.Object);
            
            var result = target.Post(new Task());
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        
        [Test]
        public void WhenPostTaskAndValidationOk_ThenReturnOk()
        {
            var tasksServiceMock = new Mock<ITaskService>();
            var tasksValidatorMock = new Mock<ITasksValidator>();
            var target = new TasksController(tasksServiceMock.Object, tasksValidatorMock.Object);
            
            var result = target.Post(new Task());
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}