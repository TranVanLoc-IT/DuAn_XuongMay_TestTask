using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Services.OrderService
{
    public interface IOrderService<T> where T : Donhang
    {
        Task<T?> GetOrCheckOrderAsync(int maDonHang);
        Task<IEnumerable<T>> GetOrdersAsync();
        Task<T> CreateOrderAsync(T donhang);
        Task<T> UpdateOrderAsync(T donhang);
        Task<bool> DeleteOrderAsync(int maDonHang);
        Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int index, int pageSize);

    }
}
