using Microsoft.Extensions.DependencyInjection;
using Play.Identity.Entities;
using Play.Identity.Services;

namespace Play.Identity
{
    public static class Extensions
    {
        public static UserDto AsDto(this ApplicationUser user)
        {
            return new UserDto(
                user.Id,
                user.UserName,
                user.Email,
                user.CreatedOn,
                user.Cash
            );
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();

            return services;
        }
    }
}