using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Data;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace MVCAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext context;


        public AccountController(ApplicationContext context)
        {
            this.context = context;
        }




        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginSignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = context.Users.Where(e => e.Email == model.Email).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = (data.Email == model.Email && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", model.Email);
                        return RedirectToAction("SignedIn", "LoggedIn");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Invalid Credentials";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Invalid Credentials";
                    return View(model);
                }
            }
            return View();
        }





        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);

            }
            
            return RedirectToAction("Index", "Home");

        }
        



        [AcceptVerbs("Post","Get")]
        public IActionResult EmailExist(string Email)
        {
            var data = context.Users.Where(e => e.Email == Email).SingleOrDefault();
            if(data != null)
            {
                return Json( "This Email is already registered");
            }
            else
            {
                return Json(true);
            }
        }





        public IActionResult Signup()
        {
            return View();

        }


        


        [HttpPost]
        public IActionResult Signup(SignupUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password=model.Password,
                };
                context.Users.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "You can Login";
                return RedirectToAction("Login");
                
            }
            else
            {
                TempData["errorMessage"] = "Empty Form Cannot be Submitted";
            }
            return View();
        }
    }
}
