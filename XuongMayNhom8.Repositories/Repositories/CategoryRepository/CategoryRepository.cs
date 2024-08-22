using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository<Danhmuc>
    {
        private readonly XmbeContext _context;
        private readonly DbSet<Danhmuc> _dbSet;
        public CategoryRepository(XmbeContext context)
        {
            _context = context;
            _dbSet = _context.Danhmucs;
        }
        public async Task Add(Danhmuc Category)
        {
            await _context.Danhmucs.AddAsync(Category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Danhmuc check = await this._dbSet.FindAsync(id);
            if (check != null)
            {
                this._dbSet.Remove(check);
                await this._context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Danhmuc>> GetAll()
        {
            return await _context.Danhmucs.ToListAsync();
        }

        public async Task<Danhmuc?> GetByCondition(Expression<Func<Danhmuc, bool>> expression)
        {
            return await _context.Danhmucs.FirstOrDefaultAsync(expression);
        }

        public async Task<Danhmuc?> GetByID(int id)
        {
            return await _context.Danhmucs.FirstOrDefaultAsync(e => e.Madm == id);
        }

        public async Task Update(Danhmuc Cate)
        {
            var category = await GetByCondition(c => c.Madm == Cate.Madm);
            if (category != null)
            {
                _context.Entry(category).State = EntityState.Modified;
                category.Madm = Cate.Madm;
                category.Tendm = Cate.Tendm;
                await _context.SaveChangesAsync();
            }
        }
    }
}
