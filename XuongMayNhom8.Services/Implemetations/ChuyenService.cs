using XuongMayNhom8.Repositories.Interfaces;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Interfaces;

namespace XuongMayNhom8.Services.Implemetations
{
	public class ChuyenService(IChuyenRepository repository) : IChuyenService
	{
		private readonly IChuyenRepository _chuyenRepository = repository;

		public async Task<IEnumerable<Chuyen>> GetAll()
		{
			return await _chuyenRepository.GetAll();
		}

		public async Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize)
		{
			return await _chuyenRepository.GetAll(pageNumber, pageSize);
		}

		public async Task<Chuyen> GetById(int maChuyen)
		{
			try
			{
				return await _chuyenRepository.GetById(maChuyen) ?? throw new KeyNotFoundException("Chuyen not found");
			}
			catch (KeyNotFoundException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the Chuyen", ex);
			}
		}

		public async Task Add(Chuyen chuyen)
		{
			await _chuyenRepository.Add(chuyen);
		}

		public async Task Update(Chuyen chuyen)
		{
			await _chuyenRepository.Update(chuyen);
		}

		public async Task Delete(int maChuyen)
		{
			try
			{
				_ = await _chuyenRepository.GetById(maChuyen) ?? throw new KeyNotFoundException("Chuyen not found");
				await _chuyenRepository.Delete(maChuyen);
			}
			catch (KeyNotFoundException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while deleting the Chuyen", ex);
			}
		}
	}
}
