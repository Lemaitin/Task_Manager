using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task <IEnumerable<TodoItem>> GetItemList()
		{
			return await _db.TodoItems.ToListAsync();
		}

		public async Task <TodoItem> GetItem(int id)
		{
			return await _db.TodoItems.FindAsync(id);
		}

		public void Create(TodoItem item)
		{
			_db.TodoItems.Add(item);
			_db.SaveChanges();
		}

		public void Update(TodoItem item)
		{
			_db.Entry(item).State = EntityState.Modified;
			_db.Update(item);
			_db.SaveChanges();
		}

		public async Task Delete(int id)
		{
			var todoItem = await GetItem(id);

			if (todoItem != null)
			{
				_db.TodoItems.Remove(todoItem);
				await _db.SaveChangesAsync();
			}
		}

		//public async Task <TodoItem> Save()
		//{
		//	return await _db.SaveChanges();
		//}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_db.Dispose();
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
