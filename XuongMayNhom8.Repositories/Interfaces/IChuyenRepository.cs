using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Interfaces
{
	public interface IChuyenRepository
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