using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Configuration;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.ProductionLineRepository
{
    public interface IProductionLineRepository
    {
        Task<IEnumerable<Chuyen>> GetAll();
        Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize);
        Task<Chuyen?> GetById(int chuyenId);
        Task Add(Chuyen chuyen);
        Task Delete(int chuyenId);
        Task Update(Chuyen chuyen);
        Task<bool> Exists(int chuyenId);
    }
}
