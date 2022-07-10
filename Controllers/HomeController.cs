using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAssignment.Data;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;


using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationContext context;


        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}



        

        public IActionResult Index()
        {

            IEnumerable<EventDetails> objList = context.Event;
            return View(objList);
        } 




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
