using Application.Interface.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;


        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost]
        [Route("CreateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Model.Order.Order>> CreateAsync(Model.Order.Order model)
        {
            return await _order.CreateAsync(model);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<bool>> UpdateAsync(Model.Order.Order model)
        {
            return await _order.UpdateAsync(model);
        }


        [HttpGet]
        [Route("Orders")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Model.Order.Order>>> Orders(int orderID)
        {
            return await _order.Orders(orderID);
        }
    }
}
