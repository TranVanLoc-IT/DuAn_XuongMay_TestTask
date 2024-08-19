using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        // DI dbcontext
        private readonly XmbeContext _dbContext;

        public OrderRepository(XmbeContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Donhang> CreateOrderAsync(Donhang donHang)
        {
            Donhang isExistedOrder = this._dbContext.Donhangs.Find(donHang.Madon);
            if(isExistedOrder != null)
            {
                return null;
            }
            await this._dbContext.Donhangs.AddAsync(donHang);
            await this._dbContext.SaveChangesAsync();
            return donHang;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            Donhang isExistedOrder = this._dbContext.Donhangs.Find(orderId);
            if (isExistedOrder != null)
            {
                this._dbContext.Donhangs.Remove(isExistedOrder);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Donhang?> GetOrCheckOrderAsync(int orderId)
        {
            return await this._dbContext.Donhangs.FindAsync(orderId);
        }   

        public async Task<IEnumerable<Donhang>> GetOrdersAsync()
        {
            return await this._dbContext.Donhangs.ToListAsync();
        }

        public async Task<Donhang?> UpdateOrderAsync(Donhang donHang)
        {
            // raise error "The instance cannot be tracked", theo dõi nhiều entity cùng lúc trong một dbcontext khi lấy ra/thay đổi
            // first entity can be tracked, id = 100 same id with donhang.madon=100 => similar and track at same dbcontext
            // can use this._dbContext.Donhangs.asnotracking() to resolve or refer below
            // chỉ đọc bỏ cx dc nhưng update change thì ko nên
            Donhang isExistedOrder = await this._dbContext.Donhangs.FindAsync(donHang.Madon);
            if (isExistedOrder != null)
            {
                // resolve this error by detached one and modified object need to be update
                this._dbContext.Entry(isExistedOrder).State = EntityState.Detached;
                this._dbContext.Entry(donHang).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                return donHang;
            }
            return null;
        }

    }
}
