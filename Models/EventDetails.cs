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
       

        [Key]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int StartTime { get; set; }

        public string TypeOfEvent { get; set; }

       
        public string InviteByEmail { get; set; }


        public string Email { get; set; }


        [ForeignKey("Email")]
        public virtual User Users { get; set; }

        

    }
}
