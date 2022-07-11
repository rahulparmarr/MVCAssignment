using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAssignment.Data;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace MVCAssignment.Controllers
{
    public class EventInformationController : Controller
    {
        private readonly ApplicationContext context;


        public EventInformationController(ApplicationContext context)
        {
            this.context = context;
        }




        public IActionResult EventInfo(string title)
        {
            //IEnumerable<EventDetails> objList = context.Event;
            //return View(objList);
           
            EventDetails details = context.Event.Single(d => d.Title == title);
            return View(details);


            
        }



        public IActionResult Edit(string title)
        {

            EventDetails EditData = context.Event.Single(d => d.Title == title);
            return View(EditData);
        }




        [HttpPost]
        public IActionResult Edit(EventDetails e)

        {

            ViewData["email"] = User.FindFirst(ClaimTypes.Email).Value;

            context.Entry(e).State = EntityState.Modified;
            int a = context.SaveChanges();
            if (a > 0)
            {
                ViewBag.edit = "<script>alert('Event is updated !')</script>";
                ModelState.Clear();

            }
            else
            {
                ViewBag.edit = "<script>alert('Event is not updated !')</script>";
            }
            return View();

        }

    }
}
