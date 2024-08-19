using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.UserRepository;

namespace XuongMayNhom8.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateUserAsync(User user)
        {
            return _userRepository.CreateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(Guid id)
        {
            return (_userRepository.DeleteUserAsync(id));
        }

        public Task<User?> GetUserByIdAsync(Guid id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            return _userRepository.GetUsersAsync();
        }

        public Task<User?> UpdateUserAsync(User user)
        {
            return _userRepository.UpdateUserAsync(user);
        }
    }
}
