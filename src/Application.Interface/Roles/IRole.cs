using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Roles
{
    public interface IRole
    {
        Task<List<Application.Model.UserRoles.Roles>> GetRolesByUserId(int userId, string dbName);
        Task<List<Application.Model.UserRoles.Roles>> GetRolesByIds(string roleIDs, string dbName);
    }
}
