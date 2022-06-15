using Application.Interface.RservationStatus;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.ReservationStatus
{
    public class ReservationStatusRepository : IReservationStatus
    {
        private readonly IConfiguration _config;
        public ReservationStatusRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Model.ReservationStatus.ReservationStatus>> ReservationStatuses()
        {


            try
            {
                const string sql = "SELECT * FROM reservationstatus";
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Newtryx"));
                return connection.Query<Model.ReservationStatus.ReservationStatus>(sql).ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
