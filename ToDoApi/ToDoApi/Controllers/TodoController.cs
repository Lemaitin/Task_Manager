using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Service.Interfaces;
using NSwag.Annotations;

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
		[Route("getItems")]
		[SwaggerDefaultResponse]
		[SwaggerResponse(500, typeof(TodoItem))]
		public async Task<ActionResult<IEnumerable<TodoItem>>> GetItems()
		{
			return Ok(await _todoService.GetItemsAsync());
		}

		[HttpGet("{id}")]
		[Route("getItem")]
		[SwaggerDefaultResponse]
		[SwaggerResponse(500, typeof(TodoItem))]
		public async Task<ActionResult<TodoItem>> GetItem(int id)
		{
			TodoItem todoItem = await _todoService.GetItemAsync(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return new ObjectResult(todoItem);
		}

		[HttpPost]
		[Route("createItem")]
		[SwaggerDefaultResponse]
		[SwaggerResponse(500, typeof(TodoItem))]
		public async Task CreateItem(TodoItem item)
		{
			if (item == null)
			{
				BadRequest();
			}

			await _todoService.CreateAsync(item);
		}

		[HttpPut]
		[Route("updateItem")]
		[SwaggerDefaultResponse]
		[SwaggerResponse(500, typeof(TodoItem))]
		public async Task UpdateItem(TodoItem item)
		{
			if (item == null)
			{
				BadRequest();
			}

			await _todoService.UpdateAsync(item);
		}

		[HttpDelete("{id}")]
		[Route("deleteItem")]
		[SwaggerDefaultResponse]
		[SwaggerResponse(500, typeof(TodoItem))]
		public async Task DeleteItem(int id)
		{
			await _todoService.DeleteAsync(id);
		}
	}
}
