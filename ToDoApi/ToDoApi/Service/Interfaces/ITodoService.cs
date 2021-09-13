using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Service.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetItemsAsync();

        Task<TodoItem> GetItemAsync(int id);

        Task CreateAsync(TodoItem item);

        Task UpdateAsync(TodoItem item);

        Task DeleteAsync(int id);
    }
}