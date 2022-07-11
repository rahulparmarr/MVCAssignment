using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MVCAssignment.Data;
using MVCAssignment.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVCAssignment.Controllers
{
    public class LoggedInController : Controller
    {
        private readonly ApplicationContext context;


        public LoggedInController(ApplicationContext context)
        {
            this.context = context;


        }





        public IActionResult SignedIn()
        {
            IEnumerable<EventDetails> objList = context.Event;
            return View(objList);
            
        }



        public IActionResult MyEvents()
        {



            ViewData["email"] = User.FindFirst(ClaimTypes.Email).Value;

            IEnumerable<EventDetails> objList = context.Event;
            return View(objList);

        }


        public IActionResult EventsInvitedTo()
        {
            ViewData["email"] = User.FindFirst(ClaimTypes.Email).Value;

            IEnumerable<EventDetails> objList = context.Event;
            return View(objList);
            
        }


    


        public IActionResult CreateEvent()
        {
            return View();
        }



        [Authorize]
        [HttpPost]
        public IActionResult CreateEvent(EventDetails model)
        {
            if (ModelState.IsValid)
            {


                var data = new EventDetails
                {

                    Title = model.Title,
                    Date = model.Date,
                    Location = model.Location,
                    StartTime = model.StartTime,
                    TypeOfEvent = model.TypeOfEvent,
                    InviteByEmail = model.InviteByEmail,
                    Email = model.Email,


                };


                context.Event.Add(data);
                context.SaveChanges();



                TempData["successMessage"] = "Event created successfully";

                


                return RedirectToAction("SignedIn");

               

            }

            else
            {
                TempData["errorMessage"] = "Please fill all the details";
            }
            return View();




        }


        







    }









    








}
