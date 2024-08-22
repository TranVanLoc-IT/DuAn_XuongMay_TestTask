using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Context;

namespace XuongMayNhom8.Repositories.Repositories.OrderRepository
{
    public class OrderRepository<T> : IOrderRepository<T> where T: Donhang
    {
        // DI dbcontext
        private readonly XmbeContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public OrderRepository(XmbeContext dbContext)
        {
            this._dbContext = dbContext;
            _dbSet = this._dbContext.Set<T>(); // get table
        }
        public async Task<T> CreateOrderAsync(T order)
        {
            T isExistedOrder = await this._dbSet.FindAsync(order);
            if(isExistedOrder != null)
            {
                return null;
            }
            if (CheckProductQuantityInvalidAsync(order))
            {
                return null;
            }
            this._dbSet.Add(order);
            await this._dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            T isExistedOrder = await this._dbSet.FindAsync(orderId);
            if (isExistedOrder != null)
            {
                this._dbSet.Remove(isExistedOrder);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<T?> GetOrCheckOrderAsync(int orderId)
        {
            return await this._dbSet.FindAsync(orderId);
        }   

        public async Task<IReadOnlyCollection<Donhang>> GetOrdersAsync(int pageNumber, int pageSize)
        {
            var orders = await _dbSet.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return orders;
        }
        public async Task<T?> UpdateOrderAsync(T order)
        {
            // raise error "The instance cannot be tracked", theo dõi nhiều entity cùng lúc trong một dbcontext khi lấy ra/thay đổi
            // first entity can be tracked, id = 100 same id with T.madon=100 => similar and track at same dbcontext
            // can use this._dbSet.asnotracking() to resolve or refer below
            // chỉ đọc bỏ cx dc nhưng update change thì ko nên
            T isExistedOrder = await this._dbSet.FindAsync(order.Madon);
            if (isExistedOrder != null)
            {
                if (CheckProductQuantityInvalidAsync(order))
                {
                    return null;
                }
                // resolve this error by detached one and modified object need to be update
                this._dbSet.Entry(isExistedOrder).State = EntityState.Detached;
                this._dbSet.Entry(order).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                return order;
            }
            return null;
        }
        private bool CheckProductQuantityInvalidAsync(T order)
        {
            int existingQuantity = this._dbContext.Sanphams.Where(sp=>sp.Masp == order.Masp).Select(sp=>sp.SoLuongCon).FirstOrDefault()??0;
            if (order.Soluong > existingQuantity)
            {
                return false;
            }
            return true;
        }
        public Task<IReadOnlyCollection<T>> PaginatePage(IQueryable<T> query, int page, int pageSize)
        {
            return null;
        }
    }
}
