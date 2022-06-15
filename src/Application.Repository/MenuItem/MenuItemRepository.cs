using Application.Interface.MenuItem;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MenuItem
{
    public class MenuItemRepository : IMenuItem
    {
        private readonly IConfiguration _config;
        public MenuItemRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Model.MenuItem.MenuItem> CreateAsync(Model.MenuItem.MenuItem MenuItem)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(MenuItem);
                MenuItem.MenuItemId = (int)userId;
                return MenuItem;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Model.MenuItem.MenuItem> FindByIdAsync(int MenuItemID)
        {
            const string sql = "SELECT * FROM MenuItem WHERE MenuItemID = @MenuItemID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.MenuItem.MenuItem>(sql, new { MenuItemID }).FirstOrDefault();
        }

        public async Task<List<Model.MenuItem.MenuItem>> Items()
        {
            const string sql = "SELECT * FROM MenuItem";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.MenuItem.MenuItem>(sql).ToList();
        }

        public async Task<bool> UpdateAsync(Model.MenuItem.MenuItem MenuItem)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(MenuItem);
        }
    }
}
