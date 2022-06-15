using Application.Interface.Rservation;
using Application.Model.Order;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Reservation
{
    public class ReservationRepository : IReservation
    {
        private readonly IConfiguration _config;
        public ReservationRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Model.Reservation.Reservation> CreateAsync(Model.Reservation.Reservation Reservation)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                var userId = connection.Insert(Reservation);
                Reservation.reservationID = (int)userId;
                return Reservation;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Model.Reservation.Reservation> FindByIdAsync(int ReservationID)
        {
            const string sql = "SELECT * FROM Reservation where reservationID = @ReservationID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { ReservationID }).FirstOrDefault();
        }

        public async Task<List<Model.Reservation.Reservation>> FindReservationByIdAsync(int ReservationID)
        {
            const string sql = "SELECT * FROM Reservation WHERE ReservationID = @ReservationID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { ReservationID }).ToList();
        }

        public async Task<List<Model.Reservation.Reservation>> FindReservationRestaurantByIdAsync(int RestaurantID)
        {
            const string sql = "SELECT * FROM Reservation WHERE RestaurantID = @RestaurantID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { RestaurantID }).ToList();
        }

        public async Task<List<Model.Reservation.Reservation>> Reservations()
        {
            const string sql = "SELECT * FROM Reservation";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql).ToList();
        }

        public async Task<bool> UpdateAsync(Model.Reservation.Reservation Reservation)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return await connection.UpdateAsync(Reservation);
        }

        public async Task<List<Model.Reservation.Reservation>> UserReservations(int userID)
        {           
            const string sql = @"SELECT RS.Name as RestaurantName, R.* FROM Reservation R
                                 INNER JOIN Restaurant RS ON RS.RestaurantID = R.RestaurantID 
                                 WHERE R.CreatedByUserID = @userID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { userID }).ToList();
        }

        public async Task<List<Model.Reservation.Reservation>> GetUserReservationsByStatus(int userID, int ReservationStatusID)
        {
            const string sql = "proc_GetUserReservationsByStatus";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { userID  = userID , ReservationStatusID  = ReservationStatusID }, commandType: CommandType.StoredProcedure).ToList();
        }

        public async Task<List<Model.Reservation.Reservation>> GetReservationsByStatus(int ReservationStatusID)
        {
            const string sql = "proc_GetReservationsByStatus";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
            return connection.Query<Model.Reservation.Reservation>(sql, new { ReservationStatusID = ReservationStatusID }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
