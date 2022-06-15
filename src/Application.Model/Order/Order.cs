using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.Order
{
    [Table("Order")]
    public class Order
    {
        [Dapper.Contrib.Extensions.Key]
        public int orderID { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Plates { get; set; }
        public int RestaurantID { get; set; }
        public int ReservationID { get; set; }
        public int MenuItemID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedByUserID { get; set; }
    }
}
