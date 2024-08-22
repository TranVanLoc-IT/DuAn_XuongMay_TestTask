using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8;
namespace XuongMayNhom8.Repositories.Repositories.OrderRepository
{
    public interface IOrderRepository<T> where T: Donhang
    {
        Task<T> CreateOrderAsync(T order);
        Task<IReadOnlyCollection<Donhang>> GetOrdersAsync(int pageNumber, int totalPage);
        Task<T?> GetOrCheckOrderAsync(int orderId);
        Task<T?> UpdateOrderAsync(T order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int index, int pageSize);

    }
}
