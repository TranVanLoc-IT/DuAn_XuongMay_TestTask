using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Services.OrderService
{
    public interface IProductionLineService<T> where T : Donhang
    {
        Task<T?> GetOrCheckOrderAsync(int maDonHang);
        Task<PagedResult<Donhang>> GetOrdersAsync(int pageNumber, int pageSize);
        Task<T> CreateOrderAsync(T donhang);
        Task<T> UpdateOrderAsync(T donhang);
        Task<bool> DeleteOrderAsync(int maDonHang);
        Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int index, int pageSize);

    }
}
