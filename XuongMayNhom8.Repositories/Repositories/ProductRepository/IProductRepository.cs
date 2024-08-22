using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Sanpham>> GetAll();
        Task<Sanpham> GetByID(int id);
        Task Add(Sanpham entity);
        Task Update(Sanpham entity);
        Task<bool> Delete(int id);
        Task<Sanpham> GetByCondition(Expression<Func<Sanpham, bool>> expression);
    }
}
