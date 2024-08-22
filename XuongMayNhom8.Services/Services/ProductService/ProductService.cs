using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.ProductRepository;

namespace XuongMayNhom8.Services.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task CreatePro(Sanpham Pro)
        {
            var _pro = new Sanpham
            {
                Masp = Pro.Masp,
                Tensp = Pro.Tensp,
                Madm = Pro.Madm,
                GiaBan = Pro.GiaBan,
                Mota = Pro.Mota,
                SoLuongCon = Pro.SoLuongCon,
                XuatXu = Pro.XuatXu,

            };
            await _repo.Add(_pro);
        }

        public async Task<bool> DeletePro(int id)
        {
            return await this._repo.Delete(id);
        }

        public async Task<IEnumerable<Sanpham>> GetAllProducts()
        {
            return await _repo.GetAll();
        }

        public async Task<Sanpham> GetProduct(Expression<Func<Sanpham, bool>> expression)
        {
            return await _repo.GetByCondition(expression);
        }

        public async Task UpdateProduct(int id, Sanpham Pro)
        {
            var pro = new Sanpham
            {
                Masp = id,
                Tensp = Pro.Tensp,
                Madm = Pro.Madm,
                GiaBan = Pro.GiaBan,
                Mota = Pro.Mota,
                SoLuongCon = Pro.SoLuongCon,
                XuatXu = Pro.XuatXu,
            };
            await _repo.Update(pro);
        }
    }
}
