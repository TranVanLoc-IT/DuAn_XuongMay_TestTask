using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Configuration;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.ProductionLineRepository
{
    public class ProductionLineRepository(XmbeContext context) : IProductionLineRepository
    {
        private readonly XmbeContext _context = context;

        // Retrieves all Chuyen records without tracking changes for better performance
        public async Task<IEnumerable<Chuyen>> GetAll()
        {
            return await _context.Chuyens.AsNoTracking().ToListAsync();
        }

        // Retrieves a paginated list of Chuyen records
        public async Task<PagedResult<Chuyen>> GetAll(int pageNumber, int pageSize)
        {
            // Skip() is not supported in EF Core 2.1
            var chuyens = await _context.Chuyens.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            int totalRecords = await _context.Chuyens.CountAsync();
            return new PagedResult<Chuyen>(chuyens, totalRecords, pageNumber, pageSize);

        }

        // Retrieves a single Chuyen by its ID
        public async Task<Chuyen?> GetById(int chuyenId)
        {
            return await _context.Chuyens.FindAsync(chuyenId);
        }

        // Adds a new Chuyen record
        public async Task Add(Chuyen chuyen)
        {
            await _context.Chuyens.AddAsync(chuyen);
            await _context.SaveChangesAsync();
        }

        // Deletes a Chuyen record and all associated Congviecs (tasks)
        public async Task Delete(int chuyenId)
        {
            // Includes related Congviecs to ensure they are also deleted
            var chuyen = await _context.Chuyens
                .Include(c => c.Congviecs)
                .SingleOrDefaultAsync(c => c.Machuyen == chuyenId);

            if (chuyen?.Congviecs != null)
            {
                _context.Congviecs.RemoveRange(chuyen.Congviecs); // Remove all Congviecs associated with the Chuyen

                _context.Chuyens.Remove(chuyen); // Remove the Chuyen

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Chuyen not found");
            }
        }

        // Updates an existing Chuyen record
        public async Task Update(Chuyen chuyen)
        {
            // Ensure the Chuyen exists
            var existingChuyen = await _context.Chuyens.FindAsync(chuyen.Machuyen) ?? throw new KeyNotFoundException("Chuyen not found");

            _context.Entry(existingChuyen).State = EntityState.Detached;
            _context.Chuyens.Update(chuyen);
            await _context.SaveChangesAsync();
        }

        // Checks if a Chuyen record exists
        public async Task<bool> Exists(int chuyenId)
        {
            return await _context.Chuyens.AnyAsync(c => c.Machuyen == chuyenId);
        }
    }
}
