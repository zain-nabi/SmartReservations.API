using Application.Interface.TableSettings;
using Application.Model.TableSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableSettingsController : ControllerBase
    {
        private readonly ITableSettings _tableSettings;
        public TableSettingsController(ITableSettings tableSettings)
        {
            _tableSettings = tableSettings;
        }

        [HttpPost]
        [Route("CreateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<TableSettings>> CreateAsync(TableSettings model)
        {
            return await _tableSettings.CreateAsync(model);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<bool>> UpdateAsync(TableSettings model)
        {
            return await _tableSettings.UpdateAsync(model);
        }

        [HttpGet]
        [Route("Tables")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<TableSettings>>> Tables(int RestaurantID)
        {
            return await _tableSettings.Tables(RestaurantID);
        }
    }
}
