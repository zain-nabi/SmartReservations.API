using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Rservation
{
    public  interface IReservation
    {
        Task<Model.Reservation.Reservation> CreateAsync(Model.Reservation.Reservation Reservation);
        Task<bool> UpdateAsync(Model.Reservation.Reservation Reservation);
        Task<List<Model.Reservation.Reservation>> FindReservationByIdAsync(int ReservationID);
        Task<List<Model.Reservation.Reservation>> FindReservationRestaurantByIdAsync(int RestaurantID);
        Task<List<Model.Reservation.Reservation>> UserReservations(int userID);
        Task<List<Model.Reservation.Reservation>> Reservations();
        Task<Model.Reservation.Reservation> FindByIdAsync(int ReservationID);
        Task<List<Model.Reservation.Reservation>> GetUserReservationsByStatus(int userID, int ReservationStatusID);
        Task<List<Model.Reservation.Reservation>> GetReservationsByStatus(int ReservationStatusID);
    }
}
