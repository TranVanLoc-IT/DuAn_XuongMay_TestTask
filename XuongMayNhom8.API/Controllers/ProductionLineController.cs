using Microsoft.AspNetCore.Mvc;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Services.ProductionLineService;
namespace XuongMayNhom8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController(IProductionLineService service) : ControllerBase
    {
        private readonly IProductionLineService _chuyenService = service;

        // GET: api/<ChuyenController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var chuyens = await _chuyenService.GetAll();
                return Ok(chuyens);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // GET api/<ChuyenController>/{pageNumber}/{pageSize}
        [HttpGet("page/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest(new { Message = "Page number and page size must be greater than zero." });
            }
            try
            {
                PagedResult<Chuyen> chuyens = await _chuyenService.GetAll(pageNumber, pageSize);
                return Ok(chuyens);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // GET api/<ChuyenController>/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var chuyen = await _chuyenService.GetById(id);
                return Ok(chuyen);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Chuyen with ID {id} not found." });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // POST api/<ChuyenController>
        [HttpPost]
        public async Task<IActionResult> Add(Chuyen chuyen)
        {
            try
            {
                if (chuyen is null)
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                await _chuyenService.Add(chuyen);
                return CreatedAtAction(nameof(GetById), new { id = chuyen.Machuyen }, chuyen);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        // DELETE api/<ChuyenController>/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _chuyenService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
            }
        }

        // PUT api/<ChuyenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Chuyen chuyen)
        {
            if (chuyen is null)
            {
                return BadRequest(new { Message = "Invalid input data." });
            }

            if (id != chuyen.Machuyen)
            {
                return BadRequest(new { Message = "ID in URL does not match ID in request body." });
            }

            try
            {
                await _chuyenService.Update(chuyen);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Chuyen with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
    }
}