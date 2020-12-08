using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoer.Api.Models;
using ToDoer.Api.Services;
using ToDoer.Api.Validation;

namespace ToDoer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITasksValidator _tasksValidator;

        public TasksController(ITaskService taskService, ITasksValidator tasksValidator)
        {
            _taskService = taskService;
            _tasksValidator = tasksValidator;
        }
        
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _taskService.Get();
        }
        
        [HttpPost]
        public void Post(Task task)
        {
            _tasksValidator.Validate(task);
            _taskService.Insert(task);
        }
    }
}