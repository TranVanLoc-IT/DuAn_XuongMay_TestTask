using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Interfaces;

namespace XuongMayNhom8.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChuyenController(IChuyenService service) : ControllerBase
	{
		private readonly IChuyenService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var chuyens = await _service.GetAll();
				return Ok(chuyens);
			} catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
			}
		}

		[HttpGet("page/{pageNumber}/{pageSize}")]
		public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
		{
			try
			{
				var chuyens = await _service.GetAll(pageNumber, pageSize);
				return Ok(chuyens);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var chuyen = await _service.GetById(id);
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

		[HttpPost]
		public async Task<IActionResult> Add(Chuyen chuyen)
		{
			try
			{
				if (chuyen == null)
				{
					return BadRequest(new { Message = "Invalid input data." });
				}

				await _service.Add(chuyen);
				return CreatedAtAction(nameof(GetById), new { id = chuyen.Machuyen }, chuyen);
			}
			catch (DbUpdateException ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Database update failed.", Details = ex.Message });
			} catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Chuyen chuyen)
		{
			if (id != chuyen.Machuyen)
			{
				return BadRequest(new { Message = "ID in URL does not match ID in request body." });
			}

			try
			{
				await _service.Update(chuyen);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound(new { Message = $"Chuyen with ID {id} not found." });
			}
			catch (DbUpdateException ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Database update failed.", Details = ex.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.Delete(id);
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
	}
}
