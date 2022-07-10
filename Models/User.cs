using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Models
{
    public class User
    {
        public string FullName { get; set; }

        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
