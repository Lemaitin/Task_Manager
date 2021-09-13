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

		public async Task<IEnumerable<TodoItem>> GetItemList()
		{
			return await _itodoItemRepository.GetItemList();
		}

		public async Task<TodoItem> GetItem(int id)
		{
			return await _itodoItemRepository.GetItem(id);
		}

		public void Create(TodoItem item)
		{
			 _itodoItemRepository.Create(item);
		}

		public void Update(TodoItem item)
		{
			_itodoItemRepository.Update(item);
		}

		public async Task Delete(int id)
		{
			await _itodoItemRepository.Delete(id);
		}

		//public async Task<TodoItem> Save()
		//{
		//	return await _itodoItemRepository.Save();
		//}
	}
}
