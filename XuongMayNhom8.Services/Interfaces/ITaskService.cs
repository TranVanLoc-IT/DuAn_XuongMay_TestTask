using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Services.Interfaces
{
	public interface ITaskService
	{
		Task<IEnumerable<Congviec>> GetAll();
		Task<PagedResult<Congviec>> GetAll(int pageNumber, int pageSize);
		Task<Congviec> GetById(int taskId);
		Task Add(Congviec task);
		Task Delete(int taskId);
		Task Update(Congviec task);
		Task<bool> IsChuyenExists(int chuyenId);
	}
}
