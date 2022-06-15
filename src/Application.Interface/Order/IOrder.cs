using Application.Model.Order.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Order
{
    public  interface IOrder
    {
        Task<OrderViewModel> CreateAsync(OrderViewModel Order);
        Task<bool> UpdateAsync(Model.Order.Order Order);
        Task<List<Model.Order.Order>> Orders(int orderID);
        Task<List<Model.Order.Order>> FindByRestaurantOrderByIdAsync(int RestaurantID);
        Task<List<Model.Order.Order>> FindByReservationOrderByIdAsync(int ReservationID);
    }
}
