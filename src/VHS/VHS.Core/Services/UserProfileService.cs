using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VHS.Core.Models;

namespace VHS.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly List<UserProfile> _users = new List<UserProfile>();

        public Task<UserProfile> CreateUserAsync(string username, string password, IEnumerable<UserRole> roles)
        {
            var user = new UserProfile
            {
                Username = username,
                Password = HashPassword(password),
                UserRoles = roles.ToList()
            };

            _users.Add(user);
            return Task.FromResult(user);
        }

        public Task<UserProfile> GetUserByIdAsync(Guid userId)
        {
            var user = _users.SingleOrDefault(u => u.Uid == userId);
            return Task.FromResult(user);
        }

        public Task<UserProfile> GetUserByUsernameAsync(string username)
        {
            var user = _users.SingleOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }

        public Task UpdateUserAsync(UserProfile user)
        {
            var existingUser = _users.SingleOrDefault(u => u.Uid == user.Uid);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.UserRoles = user.UserRoles;
            }

            return Task.CompletedTask;
        }

        public Task DeleteUserAsync(Guid userId)
        {
            var user = _users.SingleOrDefault(u => u.Uid == userId);
            if (user != null)
            {
                _users.Remove(user);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<UserProfile>> GetAllUsersAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        private string HashPassword(string password)
        {
            // Implement password hashing logic here
            return password; // Simplified for development
        }
    }
}