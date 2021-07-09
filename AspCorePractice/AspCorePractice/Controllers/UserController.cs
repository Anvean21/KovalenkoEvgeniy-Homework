using AspCorePractice.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspCorePractice.Controllers
{
    public class UserController : Controller
    {
        AspCoreContext db;
        public UserController(AspCoreContext db)
        {
            this.db = db;
        }

        [Authorize]
        [Route("todos")]
        [HttpGet]
        public IActionResult Todos()
        {
            return View();
        }

        [Route("signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if (db.Users.Any(x => x.Email == user.Email))
            {
                ModelState.AddModelError("", "This email already taken");
                return View(user);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            await Authenticate(user.Email);

            return RedirectToAction("Index", "Home");
        }

        [Route("signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
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
            return RedirectToAction("Index", "Home");
        }
    }
}
