using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Services.OrderService
{
    public interface IOrderService
    {
        Task<Donhang?> GetOrCheckOrderAsync(int maDonHang);
        Task<IEnumerable<Donhang>> GetOrdersAsync();
        Task<Donhang> CreateOrderAsync(Donhang donhang);
        Task<Donhang?> UpdateOrderAsync(Donhang donhang);
        Task<bool> DeleteOrderAsync(int maDonHang);

    }
}
