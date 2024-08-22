using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.OrderRepository;
namespace XuongMayNhom8.Services.Services.OrderService
{
    public class ProductionLineService<T> : IProductionLineService<T> where T: Donhang
    {
        private readonly IOrderRepository<T> _orderRepo;
        public ProductionLineService(IOrderRepository<T> orderRepository) {
            this._orderRepo = orderRepository;
        }
        public async Task<T?> CreateOrderAsync(T order)
        {
            return await this._orderRepo.CreateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await this._orderRepo.DeleteOrderAsync(orderId);
        }

        public async Task<T?> GetOrCheckOrderAsync(int orderId)
        {
            return await this._orderRepo.GetOrCheckOrderAsync(orderId);
        }
        public async Task<PagedResult<Donhang>> GetOrdersAsync(int pageNumber, int pageSize)
        {
            var orders = await this._orderRepo.GetOrdersAsync(pageNumber, pageSize);
            int totalRecords = orders.Count();
            return new PagedResult<Donhang>(orders, totalRecords, pageNumber, pageSize);
        }

        public async Task<T?> UpdateOrderAsync(T order)
        {
            return await this._orderRepo.UpdateOrderAsync(order);
        }
        public Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int page, int pageSize) { 
            return null;
        }
    }
}
