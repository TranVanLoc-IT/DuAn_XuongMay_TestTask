using Microsoft.AspNetCore.Mvc;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Services.CategoryService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XuongMayNhom8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _context;

        public CategoryController(ICategoryService context)
        {
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet("categories")]
        public async Task<IEnumerable<Danhmuc>> GetAll()
        {
            return await _context.GetAllCategorires();
        }

        // GET api/<CategoryController>/5
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<Danhmuc>> GetById(int id)
        {
            var cate = await _context.GetCategory(i => i.Madm == id);
            if (cate == null)
            {
                return NotFound("Category does not exist !");
            }
            return Ok(cate);
        }

        // POST api/<CategoryController>
        [HttpPost("categories")]
        public async Task<ActionResult<Danhmuc>> Create([FromBody] Danhmuc value)
        {
            await _context.CreateCate(value);
            return CreatedAtAction(nameof(Create), value.GetHashCode(), value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("categories/{id}")]
        public async Task<ActionResult<Danhmuc>> Update(int id, [FromBody] Danhmuc value)
        {
            var cate = await _context.GetCategory(i => i.Madm == id);
            if (cate == null)
            {
                return BadRequest("No category was found !");
            }
            await _context.UpdateCategory(id, value);
            return Ok(cate);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.DeleteCate(id);
            if (!result)
            {
                return NotFound("Category does not exist !");
            }
            return NoContent();
        }
    }
}
