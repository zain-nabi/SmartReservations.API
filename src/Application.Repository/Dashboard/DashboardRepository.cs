using Application.Interface.Reports;
using Application.Model.Reports;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Dashboard
{
    public class DashboardRepository : IDashboard
    {
        private readonly IConfiguration _config;
        public DashboardRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<ReservationArrived> GetArrivedReservations()
        {
            const string sql = "SELECT COUNT(*) AS ArrivedCount FROM Reservation WHERE ReservationStatusID = 3";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ReservationArrived>(sql).FirstOrDefault();
        }

        public async Task<ReservationBooked> GetBookedReservations()
        {
            const string sql = "SELECT COUNT(*) AS BookedCount FROM Reservation WHERE ReservationStatusID = 1";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ReservationBooked>(sql).FirstOrDefault();
        }

        public async Task<ReservationComplete> GetCompleteReservations()
        {
            const string sql = "SELECT COUNT(*) AS CompleteCount FROM Reservation WHERE ReservationStatusID = 2";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<ReservationComplete>(sql).FirstOrDefault();
        }
    }
}
