using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Order
{
    public  interface IOrder
    {
        Task<Model.Order.Order> CreateAsync(Model.Order.Order Order);
        Task<bool> UpdateAsync(Model.Order.Order Order);
        Task<List<Model.Order.Order>> Orders(int orderID);
        Task<List<Model.Order.Order>> FindByRestaurantOrderByIdAsync(int RestaurantID);
        Task<List<Model.Order.Order>> FindByReservationOrderByIdAsync(int ReservationID);
    }
}
