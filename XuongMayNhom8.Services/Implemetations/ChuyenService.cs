using XuongMayNhom8.Repositories.Interfaces;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Interfaces;

namespace XuongMayNhom8.Services.Implemetations
{
	public class ChuyenService(IChuyenRepository repository) : IChuyenService
	{
		private readonly IChuyenRepository _chuyenRepository = repository;

		// Retrieves all Chuyen from the repository
		public async Task<IEnumerable<Chuyen>> GetAll()
		{
			return await _chuyenRepository.GetAll();
		}

		// Retrieves all Chuyen from the repository with pagination
		public async Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize)
		{
			return await _chuyenRepository.GetAll(pageNumber, pageSize);
		}

		// Retrieves a single Chuyen by its ID
		public async Task<Chuyen> GetById(int chuyenId)
		{
			return await _chuyenRepository.GetById(chuyenId) ?? throw new KeyNotFoundException("Chuyen not found");
		}

		// Adds a new Chuyen to the repository
		public async Task Add(Chuyen chuyen)
		{
			await _chuyenRepository.Add(chuyen);
		}

		// Deletes a Chuyen by its ID
		public async Task Delete(int chuyenId)
		{
			// Check if the Chuyen exists
			try
			{
				await _chuyenRepository.Delete(chuyenId);
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

		// Updates an existing Chuyen in the repository
		public async Task Update(Chuyen chuyen)
		{
			try
			{
				await _chuyenRepository.Update(chuyen);
			} catch (KeyNotFoundException)
			{
				throw;
			} catch (Exception ex)
			{
				throw new Exception("An error occurred while updating the Chuyen", ex);
			}
		}
	}
}
