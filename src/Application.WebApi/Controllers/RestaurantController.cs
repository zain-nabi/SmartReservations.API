using Application.Interface.Restaurant;
using Application.Model.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restaurant;


        public RestaurantController(IRestaurant restaurant)
        {
            _restaurant = restaurant;
        }

        [HttpGet]
        [Route("FindByIdAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Restaurant>> FindByIdAsync(int RestaurantID)
        {
            return await _restaurant.FindByIdAsync(RestaurantID);
        }


        [HttpGet]
        [Route("Restaurants")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Restaurant>>> Restaurants()
        {
            return await _restaurant.Restaurants();
        }

        [HttpGet]
        [Route("UserRestaurants")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<List<Restaurant>>> UserRestaurants(int userID)
        {
            return await _restaurant.UserRestaurants(userID);
        }

        [HttpPost]
        [Route("CreateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<Restaurant>> CreateAsync(Restaurant model)
        {
            return await _restaurant.CreateAsync(model);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        [SwaggerOperation(Summary = "FindByIdAsync - Gets the user by their UserID", Description = "Returns a single user")]
        public async Task<ActionResult<bool>> UpdateAsync(Restaurant model)
        {
            return await _restaurant.UpdateAsync(model);
        }

    }
}
