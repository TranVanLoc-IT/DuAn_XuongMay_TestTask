using XuongMayNhom8.Repositories.Interfaces;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Interfaces;

namespace XuongMayNhom8.Services.Implemetations
{
	public class TaskService(ITaskRepository taskRepository, IChuyenRepository chuyenRepository) : ITaskService
	{
		private readonly ITaskRepository _taskRepository = taskRepository;
		private readonly IChuyenRepository _chuyenRepository = chuyenRepository;

		// Retrieves all tasks (Congviec) from the repository
		public async Task<IEnumerable<Congviec>> GetAll()
		{
			return await _taskRepository.GetAll();
		}

		// Retrieves a paginated list of tasks (Congviec) from the repository
		public async Task<PagedResult<Congviec>> GetAll(int pageNumber, int pageSize)
		{
			return await _taskRepository.GetAll(pageNumber, pageSize);
		}

		// Retrieves a single task (Congviec) by its ID
		public async Task<Congviec> GetById(int taskId)
		{
			try
			{
				return await _taskRepository.GetById(taskId) ?? throw new KeyNotFoundException("Task not found");
			}
			catch(KeyNotFoundException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new Exception($"An error occurred while retrieving the Task with ID {taskId}", ex);
			}
		}

		// Adds a new task (Congviec) to the repository
		public async Task Add(Congviec task)
		{
			await _taskRepository.Add(task);
		}

		// Deletes a task (Congviec) from the repository
		public async Task Delete(int taskId)
		{
			try
			{
				await _taskRepository.Delete(taskId);
			}
			catch (KeyNotFoundException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new Exception($"An error occurred while deleting the Task with ID {taskId} ", ex);
			}
		}

		// Updates a task (Congviec) in the repository
		public async Task Update(Congviec task)
		{
			await _taskRepository.Update(task);
		}

		// Checks if a task (Congviec) exists in the repository
		public async Task<bool> IsChuyenExists(int chuyenId)
		{
			return await _chuyenRepository.Exists(chuyenId);
		}
	}
}
