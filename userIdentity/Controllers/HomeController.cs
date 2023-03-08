namespace userIdentity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username , string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                //sign in
                var sighInResult=_signInManager.PasswordSignInAsync(username, password, false, false);
                if (sighInResult.IsCompletedSuccessfully)
                {
                    return RedirectToAction("Secret");
                }                
            }
            return RedirectToAction("Error");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = ""
            };
            //This is authentication
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var signInResult = _signInManager.PasswordSignInAsync(username, password, false, false);
                if (signInResult.IsCompletedSuccessfully)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
