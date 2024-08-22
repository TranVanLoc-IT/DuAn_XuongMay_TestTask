using Microsoft.AspNetCore.Mvc;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Services.ProductService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XuongMayNhom8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;
        public ProductController(IProductService context)
        {
            _context = context;
        }
        // GET: api/<ProductController>
        [HttpGet("products")]
        public async Task<IEnumerable<Sanpham>> GetAll()
        {
            return await _context.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("products/{id}")]
        public async Task<ActionResult<Sanpham>> GetProduct(int id)
        {
            var pro = await _context.GetProduct(i => i.Masp == id);
            if (pro == null)
            {
                return NotFound("Product does not exist !!!");
            }
            return Ok(pro);
        }

        // POST api/<ProductController>
        [HttpPost("products")]
        public async Task<ActionResult<Sanpham>> Create([FromBody] Sanpham value)
        {
            await _context.CreatePro(value);
            return CreatedAtAction(nameof(Create), value.GetHashCode(), value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("products/{id}")]
        public async Task<ActionResult<Sanpham>> Update(int id, [FromBody] Sanpham value)
        {
            var pro = await _context.GetProduct(i => i.Masp == id);
            if (pro == null)
            {
                return BadRequest("No product was found !");
            }
            await _context.UpdateProduct(id, value);
            return Ok(pro);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.DeletePro(id);
            if (!result)
            {
                return NotFound("Product does not exist !");
            }
            return NoContent();
        }
    }
}
