using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoer.Api.Models;
using ToDoer.Api.Services;

namespace ToDoer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _taskService.Get();
        }
        
        [HttpPost]
        public void Post(Task task)
        {
            _taskService.Insert(task);
        }
    }
}