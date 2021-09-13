using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Service.Interfaces;
using ToDoApi.Repository.Interfaces;

namespace ToDoApi.Service
{
    public class TodoService : ITodoService
    {
        private ITodoItemRepository _itodoItemRepository;

        public TodoService(ITodoItemRepository todoItemRepository)
        {
            _itodoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            return await _itodoItemRepository.GetItemsAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await _itodoItemRepository.GetItemAsync(id);
        }

        public async Task CreateAsync(TodoItem item)
        {
            await _itodoItemRepository.CreateAsync(item);
        }

        public async Task UpdateAsync(TodoItem item)
        {
            await _itodoItemRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _itodoItemRepository.DeleteAsync(id);
        }
    }
}