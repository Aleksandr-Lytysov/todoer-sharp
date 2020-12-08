using System;
using ToDoer.Api.Models;

namespace ToDoer.Api.Validation
{   
    public interface ITasksValidator
    {
        void Validate(Task task);
    }
    
    public class TasksValidator : ITasksValidator
    {
        public void Validate(Task task)
        {
            if (string.IsNullOrEmpty(task.Content))
            {
                throw new TasksValidatorException("No task content provided");
            }
            if (task.DueTo < DateTime.UtcNow)
            {
                throw new TasksValidatorException("Task`s dueTo should later then now");
            }
            if (task.Content.Length > 100)
            {
                throw new TasksValidatorException("Task content is too long");
            }
        }
    }

    public class TasksValidatorException : Exception
    {
        public TasksValidatorException() : base() { }
        public TasksValidatorException(string message) : base(message) { }
        public TasksValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}