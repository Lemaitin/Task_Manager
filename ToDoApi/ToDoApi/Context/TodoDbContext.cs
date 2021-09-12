using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Context
{
	public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
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
