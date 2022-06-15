using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.OrderTotal
{
    [Table("OrderTotal")]
    public class OrderTotal
    {
        [Dapper.Contrib.Extensions.Key]
        public int orderTotalID { get; set; }
        public decimal OrderTotals { get; set; }
        public decimal VAT { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int OrderID { get; set; }
        public int RestauntID { get; set; }
        public int ReservationID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedByUserID { get; set; }
    }
}
