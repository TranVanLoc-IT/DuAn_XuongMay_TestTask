using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly XmbeContext _context;

        public UserRepository(XmbeContext context)
        {
            _context = context;
        }

        // Create a new user
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Get all users
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get user by ID
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Update an existing user
        public async Task<User?> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        // Delete a user by ID
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
