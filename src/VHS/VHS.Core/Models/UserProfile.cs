using System.Collections.Generic;

namespace VHS.Core.Models
{
    public class UserProfile : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public UserProfile()
        {
            UserRoles = new List<UserRole>();
        }
    }
}