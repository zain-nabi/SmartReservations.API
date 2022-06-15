using Application.Interface.MenuItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItem _menuItem;
        public MenuItemController(IMenuItem menuItem)
        {
            _menuItem = menuItem;
        }

        [HttpPost]
        [Route("CreateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.MenuItem.MenuItem>> CreateAsync(Model.MenuItem.MenuItem model)
        {
            return await _menuItem.CreateAsync(model);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<bool>> UpdateAsync(Model.MenuItem.MenuItem model)
        {
            return await _menuItem.UpdateAsync(model);
        }

        [HttpGet]
        [Route("FindByIdAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.MenuItem.MenuItem>> FindByIdAsync(int MenuItemID)
        {
            return await _menuItem.FindByIdAsync(MenuItemID);
        }

        [HttpGet]
        [Route("Items")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Model.MenuItem.MenuItem>>> Items()
        {
            return await _menuItem.Items();
        }
    }
}
