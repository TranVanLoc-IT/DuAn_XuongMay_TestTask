using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Donhang> CreateOrderAsync(Donhang donHang);
        Task<IEnumerable<Donhang>> GetOrdersAsync();
        Task<Donhang?> GetOrCheckOrderAsync(int orderId);
        Task<Donhang?> UpdateOrderAsync(Donhang donHang);
        Task<bool> DeleteOrderAsync(int orderId);

    }
}
