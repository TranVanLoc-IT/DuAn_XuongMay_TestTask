using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Interfaces;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Implemenations
{
	public class ChuyenRepository(XmbeContext context) : IChuyenRepository
	{
		private readonly XmbeContext _context = context;

		public async Task Add(Chuyen chuyen)
		{
			await _context.Chuyens.AddAsync(chuyen);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int maChuyen)
		{
			var chuyen = await _context.Chuyens.FindAsync(maChuyen);
			if (chuyen != null)
			{
				_context.Chuyens.Remove(chuyen);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException("Chuyen not found");
			}
		}

		public async Task<IEnumerable<Chuyen>> GetAll()
		{
			return await _context.Chuyens.AsNoTracking().ToListAsync();
		}

		public async Task<Chuyen> GetById(int maChuyen)
		{
			return await _context.Chuyens.FindAsync(maChuyen) ?? throw new KeyNotFoundException("Chuyen not found");
		}

		public async Task Update(Chuyen chuyen)
		{
			_context.Chuyens.Update(chuyen);
			await _context.SaveChangesAsync();
		}
	}
}