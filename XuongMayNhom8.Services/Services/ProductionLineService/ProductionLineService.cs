using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.ProductionLineRepository;
namespace XuongMayNhom8.Services.Services.ProductionLineService
{
    public class ProductionLineService : IProductionLineService
    {
        private readonly IProductionLineRepository _chuyenRepository;

        // Retrieves all ProductionLine from the repository
        public ProductionLineService(IProductionLineRepository repository)
        {
            this._chuyenRepository= repository;
        }
        public async Task<IEnumerable<Chuyen>> GetAll()
        {
            return await _chuyenRepository.GetAll();
        }

        // Retrieves all ProductionLine from the repository with pagination
        public async Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize)
        {
            return await _chuyenRepository.GetAll(pageNumber, pageSize);
        }

        // Retrieves a single ProductionLine by its ID
        public async Task<Chuyen> GetById(int chuyenId)
        {
            return await _chuyenRepository.GetById(chuyenId) ?? throw new KeyNotFoundException("ProductionLine not found");
        }

        // Adds a new ProductionLine to the repository
        public async Task Add(Chuyen chuyen)
        {
            await _chuyenRepository.Add(chuyen);
        }

        // Deletes a ProductionLine by its ID
        public async Task Delete(int chuyenId)
        {
            // Check if the ProductionLine exists
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
                throw new Exception("An error occurred while deleting the ProductionLine", ex);
            }
        }

        // Updates an existing ProductionLine in the repository
        public async Task Update(Chuyen chuyen)
        {
            try
            {
                await _chuyenRepository.Update(chuyen);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the ProductionLine", ex);
            }
        }

        public Task<bool> Exists(int chuyenId)
        {
            throw new NotImplementedException();
        }
    }
}
