using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.TableSettings
{
    [Table("TableSettings")]
    public class TableSettings
    {
        [Dapper.Contrib.Extensions.Key]
        public int TableSettingsID { get; set; }
        public int TableNo { get; set; }
        public int RestaurantID { get; set; }
        public bool isIniside { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedByUserID { get; set; }
    }
}
