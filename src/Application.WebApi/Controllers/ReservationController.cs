using Application.Interface.Rservation;
using Application.Model.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservation _reservation;


        public ReservationController(IReservation reservation)
        {
            _reservation = reservation;
        }

        [HttpPost]
        [Route("CreateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Reservation>> CreateAsync(Reservation model)
        {
            return await _reservation.CreateAsync(model);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<bool>> UpdateAsync(Reservation model)
        {
            return await _reservation.UpdateAsync(model);
        }

        [HttpGet]
        [Route("FindReservationByIdAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> FindReservationByIdAsync(int ReservationID)
        {
            return await _reservation.FindReservationByIdAsync(ReservationID);
        }

        [HttpGet]
        [Route("FindReservationRestaurantByIdAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> FindReservationRestaurantByIdAsync(int RestaurantID)
        {
            return await _reservation.FindReservationRestaurantByIdAsync(RestaurantID);
        }

        [HttpGet]
        [Route("Reservations")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> Reservations()
        {
            return await _reservation.Reservations();
        }

        [HttpGet]
        [Route("UserReservations")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> UserReservations(int userID)
        {
            return await _reservation.UserReservations(userID);
        }

        [HttpGet]
        [Route("FindByIdAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Reservation>> FindByIdAsync(int ReservationID)
        {
            return await _reservation.FindByIdAsync(ReservationID);
        }

        [HttpGet]
        [Route("GetUserReservationsByStatus")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> GetUserReservationsByStatus(int userID, int ReservationStatusID)
        {
            return await _reservation.GetUserReservationsByStatus(userID, ReservationStatusID);
        }


        [HttpGet]
        [Route("GetReservationsByStatus")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Reservation>>> GetReservationsByStatus(int userID)
        {
            return await _reservation.GetReservationsByStatus(userID);
        }
    }
}
