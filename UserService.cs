//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using System.Security.Claims;

//namespace MVCAssignment
//{
//    public class UserService
//    {
//        private readonly IHttpContextAccessor _httpContext;




//        public UserService(IHttpContextAccessor httpContext)
//        {
//            _httpContext = httpContext;
//        }
//        public string GetEmail()
//        {
//            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.Email);
//        }
//    }
//}
