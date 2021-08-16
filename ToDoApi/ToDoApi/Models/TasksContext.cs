using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
	public class TasksContext : DbContext
    {
        public DbSet<TodoItem> Tasks { get; set; }
        public TasksContext(DbContextOptions<TasksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .Property(b => b.Name)
                .IsRequired();
        }
    }
}
