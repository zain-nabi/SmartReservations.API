using Application.Interface.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;
        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;
        }

        [HttpGet]
        [Route("GetArrivedReservations")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.Reports.ReservationArrived>> GetArrivedReservations()
        {
            return await _dashboard.GetArrivedReservations();
        }

        [HttpGet]
        [Route("GetBookedReservations")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.Reports.ReservationBooked>> GetBookedReservations()
        {
            return await _dashboard.GetBookedReservations();
        }

        [HttpGet]
        [Route("GetCompleteReservations")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.Reports.ReservationComplete>> GetCompleteReservations()
        {
            return await _dashboard.GetCompleteReservations();
        }
    }
}
