using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
