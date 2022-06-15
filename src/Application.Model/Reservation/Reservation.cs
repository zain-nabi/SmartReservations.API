using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.Reservation
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Reservation")]
    public class Reservation
    {
        [Dapper.Contrib.Extensions.Key]
        public int reservationID { get; set; }
        public int People { get; set; }
        public int RestaurantID { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public int OrderTotalID { get; set; }
        public int ReservationStatusID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        [Computed]
        public string RestaurantName { get; set; }
    }
}
