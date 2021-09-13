using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetItems()
        {
            return Ok(await _todoService.GetItemsAsync());
        }

        [HttpGet("getItem/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
        public async Task UpdateItem(TodoItem item)
        {
            if (item == null)
            {
                BadRequest();
            }

            await _todoService.UpdateAsync(item);
        }

        [HttpDelete("deleteItem/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500)]
        public async Task DeleteItem(int id)
        {
            await _todoService.DeleteAsync(id);
        }
    }
}