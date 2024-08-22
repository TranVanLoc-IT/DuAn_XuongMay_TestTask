using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly XmbeContext _context;
        private readonly DbSet<Sanpham> _dbSet;
        public ProductRepository(XmbeContext context)
        {
            _context = context;
            _dbSet = _context.Sanphams;
        }
        public async Task Add(Sanpham pro)
        {
            await _context.Sanphams.AddAsync(pro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Sanpham check = await this._dbSet.FindAsync(id);
            if (check != null)
            {
                this._dbSet.Remove(check);
                await this._context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Sanpham>> GetAll()
        {
            return await _context.Sanphams.ToListAsync();
        }

        public async Task<Sanpham?> GetByCondition(Expression<Func<Sanpham, bool>> expression)
        {
            return await _context.Sanphams.FirstOrDefaultAsync(expression);
        }

        public async Task<Sanpham?> GetByID(int id)
        {
            return await _context.Sanphams.FirstOrDefaultAsync(e => e.Masp == id);
        }

        public async Task Update(Sanpham pro)
        {
            var Pro = await GetByCondition(c => c.Masp == pro.Masp);
            if (Pro != null)
            {
                _context.Entry(Pro).State = EntityState.Modified;
                Pro.Masp = pro.Masp;
                Pro.Madm = pro.Madm;
                Pro.Tensp = pro.Tensp;
                Pro.GiaBan = pro.GiaBan;
                Pro.Mota = pro.Mota;
                Pro.SoLuongCon = pro.SoLuongCon;
                Pro.XuatXu = pro.XuatXu;
                await _context.SaveChangesAsync();
            }
        }
    }
}
