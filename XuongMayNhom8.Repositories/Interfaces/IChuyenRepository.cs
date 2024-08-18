using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Interfaces
{
	public interface IChuyenRepository
	{
		Task<IEnumerable<Chuyen>> GetAll();
		Task<Chuyen> GetById(int maChuyen);
		Task Add(Chuyen chuyen);
		Task Update(Chuyen chuyen);
		Task Delete(int maChuyen);
	}
}