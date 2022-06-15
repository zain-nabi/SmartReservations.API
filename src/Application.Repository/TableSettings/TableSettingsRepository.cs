using Application.Interface.TableSettings;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.TableSettings
{
    public class TableSettingsRepository : ITableSettings
    {
        private readonly IConfiguration _config;
        public TableSettingsRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Model.TableSettings.TableSettings> CreateAsync(Model.TableSettings.TableSettings TableSettings)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(TableSettings);
                TableSettings.TableSettingsID = (int)userId;
                return TableSettings;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<Model.TableSettings.TableSettings>> Tables(int RestaurantID)
        {
            const string sql = "SELECT * FROM TableSettings WHERE RestaurantID = @RestaurantID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.TableSettings.TableSettings>(sql, new { RestaurantID }).ToList();
        }

        public async Task<bool> UpdateAsync(Model.TableSettings.TableSettings TableSettings)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(TableSettings);
        }
    }
}
