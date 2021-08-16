using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        TasksContext db;
        public TodoController(TasksContext context)
        {
            db = context;
            if (!db.Tasks.Any())
            {
                db.Tasks.Add(new TodoItem { Name = "Work", IsComplete = true });
                db.Tasks.Add(new TodoItem { Name = "Cooking", IsComplete = false });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return await db.Tasks.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            TodoItem task = await db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return NotFound();
            return new ObjectResult(task);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post(TodoItem task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<TodoItem>> Put(TodoItem task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (!db.Tasks.Any(x => x.Id == task.Id))
            {
                return NotFound();
            }

            db.Update(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> Delete(int id)
        {
            TodoItem task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            db.Tasks.Remove(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }
    }
}
