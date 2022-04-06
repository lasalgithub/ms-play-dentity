using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Play.Identity.Entities;
using Play.Identity.Services;
using static IdentityServer4.IdentityServerConstants;

namespace Play.Identity.Controllers
{

    [ApiController]
    [Route("user")]
    [Authorize(Policy = LocalApi.PolicyName, Roles = Roles.Admin)]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var users = _userServices.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(Guid id)
        {
            UserDto user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
                return NotFound($"User cannot be found with id: '{id}'");

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateUserDto updateUser)
        {
            var updatedUserStatus = await _userServices.UpdateUserAsync(updateUser);
            if (updatedUserStatus == null)
                return NotFound($"User cannot be found with id: '{updateUser.Id}'");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id)
        {
            var deleteStatus = await _userServices.DeleteUserByIdAsync(id);
            if (deleteStatus == null)
                return NotFound($"User cannot be found with id: '{id}'");

            return NoContent();
        }
    }
}