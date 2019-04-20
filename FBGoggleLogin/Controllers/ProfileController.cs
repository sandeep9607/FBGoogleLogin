using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FBGoggleLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace FBGoggleLogin.Controllers
{
    public class ProfileController : Controller
    {
        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            var vm = new ProfileViewModel
            {
                Claims = User.Claims,
                Name = User.Identity.Name
            };


            AuthenticationResult userData = new AuthenticationResult();

            string accessToken = User.FindFirst("access_token")?.Value;

            var accessToken1 = HttpContext.GetTokenAsync("access_token");


            userData.LoginProvider = User.Identity.AuthenticationType;

            userData.UserId = User.FindFirst("UserId").Value;
            userData.FirstName = User.FindFirst("FirstName").Value;
            userData.LastName = User.FindFirst("LastName").Value;
            userData.FullName = User.FindFirst("FullName").Value;
            userData.Email = User.FindFirst("Email").Value;

            return View(vm);
        }
    }
}
