using Application.Interface.Order;
using Application.Model.Order;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.OrderRepository
{




    public class OrderRepository : IOrder
    {
        private readonly IConfiguration _config;
        public OrderRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Model.Order.Order> CreateAsync(Order Order)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(Order);
                Order.orderID = (int)userId;
                return Order;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<Order>> FindByReservationOrderByIdAsync(int RestaurantID)
        {
            const string sql = "SELECT * FROM Order WHERE RestaurantID = @RestaurantID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Order.Order>(sql, new { RestaurantID }).ToList();
        }

        public async Task<List<Order>> FindByRestaurantOrderByIdAsync(int RestaurantID)
        {
            const string sql = "SELECT * FROM Order WHERE RestaurantID = @RestaurantID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Order.Order>(sql, new { RestaurantID }).ToList();
        }

        public async Task<List<Order>> Orders(int orderID)
        {
            const string sql = "SELECT * FROM Order where orderID = @orderID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Order.Order>(sql, new{ orderID}).ToList();
        }

        public async Task<bool> UpdateAsync(Order Order)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(Order);
        }
    }
}
