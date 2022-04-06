using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Play.Identity.Services
{
    public interface IUserServices
    {
        Task<string> DeleteUserByIdAsync(Guid id);
        Task<UserDto> GetUserByIdAsync(Guid id);
        IEnumerable<UserDto> GetUsers();
        Task<string> UpdateUserAsync(UpdateUserDto updateUser);
    }
}