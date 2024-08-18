using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Interfaces;

namespace XuongMayNhom8.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChuyenController : ControllerBase
	{
		private readonly IChuyenService _service;

		public ChuyenController(IChuyenService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var chuyens = await _service.GetAll();
			return Ok(chuyens);
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
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(Chuyen chuyen)
		{
			await _service.Add(chuyen);
			return CreatedAtAction(nameof(GetById), new { id = chuyen.Machuyen }, chuyen);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Chuyen chuyen)
		{
			if (id != chuyen.Machuyen)
			{
				return BadRequest();
			}

			await _service.Update(chuyen);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.Delete(id);
			return NoContent();
		}
	}
}
