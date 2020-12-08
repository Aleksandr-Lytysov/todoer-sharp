using System.Collections.Generic;
using System.Linq;
using ToDoer.Api.Data;
using ToDoer.Api.Models;

namespace ToDoer.Api.Services
{
    public interface ITaskService
    {
        IEnumerable<Task> Get();
        void Insert(Task task);
    }
    
    public class TasksService : ITaskService
    {
        private ApplicationDbContext _context;

        public TasksService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Task> Get()
        {
            return _context.Tasks.ToList();
        }

        public void Insert(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}