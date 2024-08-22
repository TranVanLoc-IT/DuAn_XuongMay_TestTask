using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Services.OrderService;
namespace XuongMayNhom8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // DI services
        private readonly IProductionLineService<Donhang> _orderService;
        public OrderController(IProductionLineService<Donhang> orderService) { 
            this._orderService = orderService;
        }

        // get one
        [HttpGet("{orderId:int}")]
        public async Task<IActionResult> GetSpecificOrder(int orderId)
        {
            // OK or NotFound
            Donhang? donHang = await _orderService.GetOrCheckOrderAsync(orderId);
            if (donHang == null)
            {
                return NotFound("Khong thay du lieu");
            }
            return Ok(donHang);
        }
        // get all
        [HttpGet]
        public async Task<IActionResult> GetAllOrder(int pageNumber = 1, int pageSize = 10)
        {
            PagedResult<Donhang> dsDonHang = await _orderService.GetOrdersAsync(pageNumber, pageSize);
            if (dsDonHang == null)
            {
                return NotFound("Khong thay du lieu");
            }
            return Ok(dsDonHang);
        }
        // create one
        [HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateOrder([FromBody] Donhang donhang)
        {
            // CreateAtAction or badrequest
            // check data fields is valid
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Donhang donHangMoi = await _orderService.CreateOrderAsync(donhang);
            if(donHangMoi == null)
            {
                return BadRequest("Order is existing");
            }
            //display data created 
            return CreatedAtAction(nameof(GetSpecificOrder), new { orderId = donhang.Madon }, donhang);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> UpdateOrder([FromBody] Donhang donhang)
        {
            // NoContent: success, NotFound: fail
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedUser = await _orderService.UpdateOrderAsync(donhang);

            if(updatedUser == null)
            {
                return NotFound("Order not found to update");
            }
            return NoContent();// was updated in the in-memory cache
        }

        [HttpDelete("{orderId:int}")]
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            // NoContent or NotFound to response
            var result = await _orderService.DeleteOrderAsync(orderId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
