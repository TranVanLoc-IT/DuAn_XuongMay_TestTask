using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.OrderRepository
{
    public interface IOrderRepository<T> where T: Donhang
    {
        Task<T> CreateOrderAsync(T order);
        Task<IEnumerable<T>> GetOrdersAsync();
        Task<T?> GetOrCheckOrderAsync(int orderId);
        Task<T?> UpdateOrderAsync(T order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int index, int pageSize);

    }
}
