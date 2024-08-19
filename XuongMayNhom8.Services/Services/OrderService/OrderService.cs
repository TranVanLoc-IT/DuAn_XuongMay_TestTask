using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.OrderRepository;

namespace XuongMayNhom8.Services.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepository) {
            this._orderRepo = orderRepository;
        }
        public async Task<Donhang?> CreateOrderAsync(Donhang donhang)
        {
            return await this._orderRepo.CreateOrderAsync(donhang);
        }

        public async Task<bool> DeleteOrderAsync(int maDonHang)
        {
            return await this._orderRepo.DeleteOrderAsync(maDonHang);
        }

        public async Task<Donhang?> GetOrCheckOrderAsync(int maDonHang)
        {
            return await this._orderRepo.GetOrCheckOrderAsync(maDonHang);
        }
        public async Task<IEnumerable<Donhang>> GetOrdersAsync()
        {
            return await this._orderRepo.GetOrdersAsync();
        }

        public async Task<Donhang?> UpdateOrderAsync(Donhang donhang)
        {
            return await this._orderRepo.UpdateOrderAsync(donhang);
        }
    }
}
