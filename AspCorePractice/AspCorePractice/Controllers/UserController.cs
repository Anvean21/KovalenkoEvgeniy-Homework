using AspCorePractice.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspCorePractice.Controllers
{
    public class UserController : Controller
    {
        AspCoreContext db;
        private readonly ILogger<UserController> _logger;

        public UserController(AspCoreContext db, ILogger<UserController> _logger)
        {
            this.db = db;
            this._logger = _logger;
        }

        public IActionResult ExceptionView()
        {
            int y = 0;
            int i = 2 / y;

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("/todos")]
        [HttpGet]
        public IActionResult Todos()
        {
            return View();
        }

        [Route("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("/signup")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user)
        {
            if (db.Users.Any(x => x.Email == user.Email))
            {
                ModelState.AddModelError("", "This email already taken");
                return View(user);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            await AuthenticateAsync(user.Email);

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/signin")]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await AuthenticateAsync(model.Email);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task AuthenticateAsync(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
