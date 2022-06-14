using Application.Interface.Roles;
using Application.Interface.User;
using Application.Repository.User;
using Application.Repository.UserRoles;
using Microsoft.Extensions.DependencyInjection;

namespace Application.WebApi.Dependancy_Injection
{
    public static class ServiceExtension
    {
        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<IExternalUser, ExternalUserRepository>();
            services.AddTransient<IExternalUserRole, ExternalUserRoleRepository>();
            services.AddTransient<IRole, RoleRepository>();
        }
    }
}
