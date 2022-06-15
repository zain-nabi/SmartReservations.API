using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.Restaurant
{
    [Table("Restaurant")]
    public  class Restaurant
    {
        [Dapper.Contrib.Extensions.Key]
        public int restaurantID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedByUserID { get; set; }
    }
}
