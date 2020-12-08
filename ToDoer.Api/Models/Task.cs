using System;

namespace ToDoer.Api.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueTo { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Opened,
        Done,
        Expired
    }
}