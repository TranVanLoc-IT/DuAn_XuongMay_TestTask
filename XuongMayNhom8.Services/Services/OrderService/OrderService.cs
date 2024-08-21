using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.OrderRepository;

namespace XuongMayNhom8.Services.Services.OrderService
{
    public class OrderService<T> : IOrderService<T> where T: Donhang
    {
        private readonly IOrderRepository<T> _orderRepo;
        public OrderService(IOrderRepository<T> orderRepository) {
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
        public async Task<IEnumerable<T>> GetOrdersAsync()
        {
            return await this._orderRepo.GetOrdersAsync();
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
