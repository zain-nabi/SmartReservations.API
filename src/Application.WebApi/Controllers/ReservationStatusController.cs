using Application.Interface.RservationStatus;
using Application.Model.ReservationStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationStatusController : ControllerBase
    {
        private readonly IReservationStatus _reservationStatus;
        public ReservationStatusController(IReservationStatus reservationStatus)
        {
            _reservationStatus = reservationStatus;
        }

        [HttpGet]
        [Route("ReservationStatuses")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<ReservationStatus>>> ReservationStatuses()
        {
            return await _reservationStatus.ReservationStatuses();
        }
    }
}
