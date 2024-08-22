using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.CategoryRepository;

namespace XuongMayNhom8.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository<Danhmuc> _repo;
        public CategoryService(ICategoryRepository<Danhmuc> repo)
        {
            _repo = repo;
        }
        public async Task CreateCate(Danhmuc Cate)
        {
            var _cate = new Danhmuc
            {
                Madm = Cate.Madm,
                Tendm = Cate.Tendm,

            };
            await _repo.Add(_cate);
        }

        public async Task<bool> DeleteCate(int id)
        {
            return await this._repo.Delete(id);
        }

        public async Task<IEnumerable<Danhmuc>> GetAllCategorires()
        {
            return await _repo.GetAll();
        }

        public async Task<Danhmuc> GetCategory(Expression<Func<Danhmuc, bool>> expression)
        {
            return await _repo.GetByCondition(expression);
        }

        public async Task UpdateCategory(int id, Danhmuc ca)
        {
            var cate = new Danhmuc { Madm = id, Tendm = ca.Tendm };
            await _repo.Update(cate);
        }
    }
}
