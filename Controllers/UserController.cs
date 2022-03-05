using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Play.Identity.Entities;
using static IdentityServer4.IdentityServerConstants;

namespace Play.Identity.Controllers
{

    [ApiController]
    [Route("user")]
    [Authorize(Policy = LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            IEnumerable<UserDto> users = userManager.Users
            .ToList()
            .Select(user => user.AsDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(Guid id)
        {
            UserDto user = (await userManager.FindByIdAsync(id.ToString())).AsDto();
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateByIdAsync(UpdateUserDto updateUser)
        {
            ApplicationUser user = await userManager.FindByIdAsync(updateUser.Id.ToString());
            if (user == null)
                return NotFound();


            user.Email = updateUser.Email;
            user.Cash = updateUser.Cash;
            await userManager.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            await userManager.DeleteAsync(user);

            return NoContent();
        }
    }
}