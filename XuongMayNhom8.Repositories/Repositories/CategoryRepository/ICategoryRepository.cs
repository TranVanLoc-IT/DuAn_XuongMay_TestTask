using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XuongMayNhom8.Repositories.Repositories.CategoryRepository
{
    public interface ICategoryRepository<DanhMuc>
    {
        Task<IEnumerable<DanhMuc>> GetAll();
        Task<DanhMuc> GetByID(int id);
        Task Add(DanhMuc entity);
        Task Update(DanhMuc entity);
        Task<bool> Delete(int id);
        Task<DanhMuc> GetByCondition(Expression<Func<DanhMuc, bool>> expression);
    }
}
