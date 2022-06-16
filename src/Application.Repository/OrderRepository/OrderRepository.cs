using Application.Interface.Order;
using Application.Model.Order;
using Application.Model.Order.Custom;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<OrderViewModel> CreateAsync(OrderViewModel Orders)
        {
            try
            {
                var Order = Extensions.ToDataTableFromList(Orders.Orders, true);
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var data = connection.Query<bool>("proc_InserOrders", new
                {
                    Orders = Order.AsTableValuedParameter("OrderTVP")
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return Orders;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Order>> FindByReservationOrderByIdAsync(int ReservationID)
        {
            const string sql = "SELECT * FROM dbo.[Order] WHERE ReservationID = @ReservationID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Order.Order>(sql, new { ReservationID }).ToList();
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
