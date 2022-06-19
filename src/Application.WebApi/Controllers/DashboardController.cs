using Application.Interface.Reports;
using Application.Reporting.IReport;
using Application.Reporting.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;
        private readonly IReport _report;
        public DashboardController(IDashboard dashboard, IReport report)
        {
            _dashboard = dashboard;
            _report = report;
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

        [HttpGet]
        [Route("GetUsersReport")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<byte[]> GetUsersReport(string reportName, string reportType)
        {
            try
            {
                return await _report.GenerateReportAsync(reportName, reportType);
                
            }
            catch (System.Exception e)
            {

                throw;
            }
            
        }
    }
}
