using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Play.Identity.Entities;

namespace Play.Identity.Services
{
    public class UserServices : IUserServices
    {
        private UserManager<ApplicationUser> _userManager;

        public UserServices(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            IEnumerable<UserDto> users = _userManager.Users
                        .ToList()
                        .Select(user => user.AsDto());
            return users;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            return user.AsDto();
        }

        public async Task<string> UpdateUserAsync(UpdateUserDto updateUser)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(updateUser.Id.ToString());
            if (user == null)
                return null;


            user.Email = updateUser.Email;
            user.Cash = updateUser.Cash;
            await _userManager.UpdateAsync(user);

            return "Updated successfully";
        }

        public async Task<string> DeleteUserByIdAsync(Guid id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;

            await _userManager.DeleteAsync(user);

            return "Deleted user successfully";
        }
    }
}