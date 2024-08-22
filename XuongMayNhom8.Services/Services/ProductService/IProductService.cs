using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Sanpham>> GetAllProducts();
        Task<Sanpham> GetProduct(Expression<Func<Sanpham, bool>> expression);
        Task CreatePro(Sanpham cate);
        Task UpdateProduct(int id, Sanpham cate);
        Task<bool> DeletePro(int id);
    }
}
