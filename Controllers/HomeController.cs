using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basics.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Authenticate()
        {
            var pocClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Akish"),
                new Claim(ClaimTypes.Email, "akish@acs.com"),
            };

            var pocIdentity = new ClaimsIdentity(pocClaims, "POC Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { pocIdentity });

            HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index");
        }
    }
}
