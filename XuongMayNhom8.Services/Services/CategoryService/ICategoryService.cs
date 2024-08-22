using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Danhmuc>> GetAllCategorires();
        Task<Danhmuc> GetCategory(Expression<Func<Danhmuc, bool>> expression);
        Task CreateCate(Danhmuc cate);
        Task UpdateCategory(int id, Danhmuc cate);
        Task<bool> DeleteCate(int id);
    }
}
