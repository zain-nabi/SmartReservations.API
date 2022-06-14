using Application.Model.UserRoles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Roles
{
    public interface IExternalUserRole
    {
        Task<List<Application.Model.UserRoles.Roles>> GetRolesByUserId(int userId, string dbName);
        Task<List<Application.Model.UserRoles.Roles>> GetRolesByIds(string roleIDs, string dbName);
        Task<ExternalUserRole> GetUserRole(int userRoleId);
        Task<long> Post(ExternalUserRole userRoles, string dbName);
        Task<bool> Put(ExternalUserRole userRoles, string dbName);
        Task<List<Application.Model.UserRoles.Roles>> GetActiveUserRoles();
        Task<ExternalUserRole> GetUserRoleByID(int externalUserID);
    }
}
