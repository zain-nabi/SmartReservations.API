using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Restaurant
{
    public interface IRestaurant
    {
        Task<Model.Restaurant.Restaurant> CreateAsync(Model.Restaurant.Restaurant Restaurant);
        Task<bool> UpdateAsync(Model.Restaurant.Restaurant Restaurant);
        Task<List<Model.Restaurant.Restaurant>> UserRestaurants(int userID);
        Task<Model.Restaurant.Restaurant> FindByIdAsync(int RestaurantID);

        Task<List<Model.Restaurant.Restaurant>> Restaurants();
    }
}
