using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Model.UserRoles
{
    public class Roles
    {
        [Required]
        public int RoleID { get; set; }

        [Required]
        public string Role { get; set; }

        public string Detail { get; set; }
    }
}
