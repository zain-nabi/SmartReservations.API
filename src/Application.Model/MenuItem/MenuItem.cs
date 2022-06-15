using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.MenuItem
{
    [Table("MenuItem")]
    public class MenuItem
    {
        [Dapper.Contrib.Extensions.Key]
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedByUserID { get; set; }
    }
}
