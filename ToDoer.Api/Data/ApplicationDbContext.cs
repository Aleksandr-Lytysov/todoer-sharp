using Microsoft.EntityFrameworkCore;
using ToDoer.Api.Models;

namespace ToDoer.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}