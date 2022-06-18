using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Reports
{
    public interface IDashboard
    {
        Task<Model.Reports.ReservationBooked> GetBookedReservations();
        Task<Model.Reports.ReservationArrived> GetArrivedReservations();
        Task<Model.Reports.ReservationComplete> GetCompleteReservations();
    }
}
