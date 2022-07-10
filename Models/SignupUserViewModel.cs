using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Models
{
    public class SignupUserViewModel
    {

        [Required(ErrorMessage ="Please enter your Name")]
        [Display(Name ="Full Name" )]
        public string FullName { get; set; }




        [Required(ErrorMessage = "Please enter your Email")]
        [Remote(action:"EmailExist",controller:"Account")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage ="please enter valid Email")]
        public string Email { get; set; }




        [Required(ErrorMessage = "Please enter Password")]
        //[RegularExpression("[5,15][!@#$%^&*()_+]",ErrorMessage ="enter atleast 5 characters with 1 special character ")]
        public string Password { get; set; }



        [Required(ErrorMessage = "Please confirm your Password")]
        [Compare("Password",ErrorMessage =("Password does not match"))]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }


        //[Display(Name="Active")]
        //public bool IsActive { get; set; }
    }
}
