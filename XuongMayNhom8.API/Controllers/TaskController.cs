using Microsoft.AspNetCore.Mvc;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Services.TaskService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XuongMayNhom8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskService.GetAll();
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // GET api/<TaskController>/{pageNumber}/{pageSize}
        [HttpGet("page/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest(new { Message = "Page number and page size must be greater than zero." });
            }
            try
            {
                PagedResult<Congviec> tasks = await _taskService.GetAll(pageNumber, pageSize);
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // GET api/<TaskController>/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Congviec task = await _taskService.GetById(id);
                return Ok(task);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Add(Congviec task)
        {
            try
            {
                if (task is null)
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                if (task.Machuyen.HasValue && !await _taskService.IsChuyenExists(task.Machuyen.Value))
                {
                    return BadRequest(new { Message = $"Can't create task because chuyen with ID {task.Machuyen} not found." });
                }

                // add check if order not exists
                if (false)
                {
                    return BadRequest(new { Message = $"Can't create task because order with ID {task.Madh} not found." });
                }


                await _taskService.Add(task);
                return CreatedAtAction(nameof(GetById), new { id = task.Machuyen }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        // DELETE api/<TaskController>/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _taskService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Chuyen with ID {id} not found." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // PUT api/<TaskController>/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Congviec task)
        {
            if (task is null)
            {
                return BadRequest(new { Message = "Invalid input data." });
            }

            if (id != task.Macv)
            {
                return BadRequest(new { Message = "ID in URL does not match ID in request body." });
            }

            if (task.Machuyen.HasValue && !await _taskService.IsChuyenExists(task.Machuyen.Value))
            {
                return BadRequest(new { Message = $"Can't update task because chuyen with ID {task.Machuyen} not found." });
            }

            // add check if order not exists
            if (false)
            {
                return BadRequest(new { Message = $"Can't update task because order with ID {task.Madh} not found." });
            }

            try
            {
                await _taskService.Update(task);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
    }
}