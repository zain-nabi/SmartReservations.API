using Application.Interface.User;
using Application.Interface.User.Custom;
using Application.Model.User;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.User
{
    public class ExternalUserRepository : IExternalUser
    {
        private readonly IConfiguration _config;
        public ExternalUserRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            const string sql = @"SELECT * FROM ExternalUser WHERE Email = @username";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ExternalUser>(sql, new { username }).FirstOrDefault();
        }

        public async Task<ExternalUser> CreateAsync(ExternalUser user)
        {

            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(user);
                user.ExternalUserID = (int)userId;
                return user;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<long> Post(ExternalUser user)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Insert(user);
        }


        public async Task<bool> PutUpdateAsync(ExternalUser user)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(user);
        }

        public async Task<ExternalUser> FindByIdAsync(int UserID)
        {
            const string sql = "SELECT * FROM ExternalUser WHERE ExternalUserID = @UserID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.QueryFirstOrDefault<ExternalUser>(sql, new { UserID });
        }


        public async Task<List<ExternalUser>> GetAllUsersInclLockedOut()
        {
            const string sql = "SELECT ExternalUserID, Username, FirstName, LastName, LockoutEnabled FROM ExternalUser ORDER BY FirstName, LastName";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ExternalUser>(sql).ToList();
        }

        public async Task<List<ExternalUserModel>> GetUserWithRoles()
        {
            const string sql = "EXEC proc_ExternalUsers_StringAgg";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ExternalUserModel>(sql).ToList();
        }
        public async Task<ExternalUser> CheckIfEmailExist(string email)
        {
            try
            {
                const string sql = "EXEC proc_Externaluser_CheckIfRegistrationExist @email";
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                return connection.Query<ExternalUser>(sql, new { email = email }).FirstOrDefault();
            }
            catch (Exception r)
            {

                throw;
            }
        }

        public async Task<ExternalUserModel> FindByExternalUserID(int externalUserID)
        {
            string sql =
                        @"SELECT 
                            EU.FirstName,
                            EU.LastName,
	                        EU.Email,
	                        EU.UserName,
	                        EU.PhoneNumber,
                            R.RoleID,
	                        R.RoleName AS UserRole,
	                        EU.LockoutEnabled,
                            EU.PasswordHash,
                            EU.ExternalUserID,
                            EU.SecurityStamp,
                            EU.PhoneNumberConfirmed,
                            EU.EmailConfirmed,
                            EU.AccessFailedCount,
                            EU.LockoutEndDateUtc
                        FROM ExternalUser EU
                        INNER JOIN ExternalUserRole EUR ON EUR.ExternalUserID = EU.ExternalUserID
                        INNER JOIN Roles R ON R.RoleID = EUR.RoleID
                        WHERE EU.ExternalUserID = @externalUserID";

            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ExternalUserModel>(sql, new { externalUserID = externalUserID }).FirstOrDefault();
        }

        public async Task<ExternalUserReportModel> GetReportUsers()
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));

            const string sql = "SELECT FirstName, LastName, Email, PhoneNumber FROM ExternalUser";
            var bookingsModel = new ExternalUserReportModel();

            using (var multi = connection.QueryMultiple(sql))
            {
                bookingsModel.ExternalUserModel = multi.Read<ExternalUserModel>().ToList();
            }

            return bookingsModel;
        }

    }
}
