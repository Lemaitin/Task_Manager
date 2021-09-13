using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Service.Interfaces
{
	public interface ITodoService
	{
		Task<IEnumerable<TodoItem>> GetItemList();

		Task<TodoItem> GetItem(int id);

		void Create(TodoItem item);

		void Update(TodoItem item);

		Task Delete (int id);

		//Task<TodoItem> Save();
	}
}
