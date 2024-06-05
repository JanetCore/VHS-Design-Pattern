using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VHS.Core.Models;

namespace VHS.Core.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> CreateUserAsync(string username, string password, IEnumerable<UserRole> roles);
        Task<UserProfile> GetUserByIdAsync(Guid userId);
        Task<UserProfile> GetUserByUsernameAsync(string username);
        Task UpdateUserAsync(UserProfile user);
        Task DeleteUserAsync(Guid userId);
        Task<IEnumerable<UserProfile>> GetAllUsersAsync();
    }
}