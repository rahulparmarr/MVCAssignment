using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Models
{
    public class EventDetails
    {
       
        [Required]
        [Key]
        public string Title { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }


        [Required]
        public int StartTime { get; set; } 


        [Required]
        public string TypeOfEvent { get; set; }

        [Required]
        public string InviteByEmail { get; set; }



        public string Email { get; set; }


        [ForeignKey("Email")]
        public virtual User Users { get; set; }

        

    }
}
