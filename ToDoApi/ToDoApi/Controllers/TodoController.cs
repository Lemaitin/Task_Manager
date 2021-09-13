using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Service.Interfaces;

namespace ToDoApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TodoController : ControllerBase
	{
		private ITodoService _todoService;

		public TodoController(ITodoService todoService)
		{
			_todoService = todoService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
		{
			return Ok(await _todoService.GetItemList());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TodoItem>> Get(int id)
		{
			TodoItem todoItem = await _todoService.GetItem(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return new ObjectResult(todoItem);
		}

		[HttpPost]
		public void Post(TodoItem item)
		{
			_todoService.Create(item);

			if (item == null)
			{
				BadRequest();
			}

			Ok(item);
		}
		[HttpPut]
		public void Put(TodoItem item)
		{
			_todoService.Update(item);

			if (item == null)
			{
				BadRequest();
			}

			Ok(item);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _todoService.Delete(id);
		}
	}
}
