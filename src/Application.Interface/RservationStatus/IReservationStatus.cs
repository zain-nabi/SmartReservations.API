using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.RservationStatus
{
    public interface IReservationStatus
    {
        Task<List<Model.ReservationStatus.ReservationStatus>> ReservationStatuses();
    }
}
