using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Context;
using ToDoApi.Models;
using ToDoApi.Repository.Interfaces;

namespace ToDoApi.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private TodoDbContext _db;

        public TodoItemRepository(TodoDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            return await _db.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await _db.TodoItems.FindAsync(id);
        }

        public async Task CreateAsync(TodoItem item)
        {
            _db.TodoItems.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoItem = await GetItemAsync(id);

            if (todoItem != null)
            {
                _db.TodoItems.Remove(todoItem);
                await _db.SaveChangesAsync();
            }
        }
    }
}