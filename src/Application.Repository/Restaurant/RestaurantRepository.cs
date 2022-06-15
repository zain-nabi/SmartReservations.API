using Application.Interface.Restaurant;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Restaurant
{
    public class RestaurantRepository : IRestaurant
    {
        private readonly IConfiguration _config;
        public RestaurantRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Application.Model.Restaurant.Restaurant> CreateAsync(Model.Restaurant.Restaurant Restaurant)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(Restaurant);
                Restaurant.restaurantID = (int)userId;
                return Restaurant;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Model.Restaurant.Restaurant> FindByIdAsync(int RestaurantID)
        {
            const string sql = "SELECT * FROM Restaurant WHERE RestaurantID = @RestaurantID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.QueryFirstOrDefault<Model.Restaurant.Restaurant>(sql, new { RestaurantID });
        }

        public async Task<bool> UpdateAsync(Model.Restaurant.Restaurant Restaurant)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(Restaurant);
        }

        public async Task<List<Model.Restaurant.Restaurant>> UserRestaurants(int userID)
        {
            const string sql = "SELECT * FROM Restaurant WHERE CreatedByUserID = @userID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Restaurant.Restaurant>(sql, new { userID }).ToList();
        }

        public async Task<List<Model.Restaurant.Restaurant>> Restaurants()
        {
            const string sql = "SELECT * FROM Restaurant";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Restaurant.Restaurant>(sql).ToList();
        }
    }
}
