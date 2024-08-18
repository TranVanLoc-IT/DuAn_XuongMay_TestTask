using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Interfaces
{
	public interface IChuyenService
	{
		Task<IEnumerable<Chuyen>> GetAll();
		Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize);
		Task<Chuyen> GetById(int maChuyen);
		Task Add(Chuyen chuyen);
		Task Update(Chuyen chuyen);
		Task Delete(int maChuyen);
	}
}
