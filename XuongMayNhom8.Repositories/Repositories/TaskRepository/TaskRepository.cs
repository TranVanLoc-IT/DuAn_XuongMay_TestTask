using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly XmbeContext _context;

        // Get all tasks
        public TaskRepository(XmbeContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Congviec>> GetAll()
        {
            return await _context.Congviecs.AsNoTracking().ToListAsync();
        }

        // Get all tasks with pagination
        public async Task<PagedResult<Congviec>> GetAll(int pageNumber, int pageSize)
        {
            // Skip() is not supported in EF Core 2.1
            var tasks = await _context.Congviecs.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            int totalRecords = await _context.Congviecs.CountAsync();
            return new PagedResult<Congviec>(tasks, totalRecords, pageNumber, pageSize);
        }

        // Get a task by id
        public async Task<Congviec?> GetById(int taskId)
        {
            return await _context.Congviecs.FindAsync(taskId);
        }

        // Add a new task
        public async Task Add(Congviec congViec)
        {
            await _context.Congviecs.AddAsync(congViec);
            await _context.SaveChangesAsync();
        }

        // Delete a task
        public async Task Delete(int taskId)
        {
            var task = await _context.Congviecs.FindAsync(taskId);
            if (task != null)
            {
                _context.Congviecs.Remove(task);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Task not found");
            }
        }

        // Update a task
        public async Task Update(Congviec task)
        {
            // Check if the task exists
            var existingChuyen = await _context.Chuyens.FindAsync(task.Macv) ?? throw new KeyNotFoundException("Chuyen not found");

            _context.Entry(existingChuyen).State = EntityState.Detached;
            _context.Congviecs.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
