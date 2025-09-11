using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;
using CarRentalSystem.Models.ViewModels;
using CarRentalSystem.Helpers;

namespace CarRentalSystem.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            if (IsLoggedIn)
                return RedirectToDashboard();

            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (IsLoggedIn)
                return RedirectToDashboard();

            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    SessionHelper.SetUserSession(HttpContext.Session, user.UserID, user.Role, user.Username);
                    return RedirectToDashboard();
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            if (IsLoggedIn)
                return RedirectToDashboard();

            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (IsLoggedIn)
                return RedirectToDashboard();

            if (ModelState.IsValid)
            {
                // Check if username already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Username already exists");
                    return View(model);
                }

                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = "Customer"
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Auto login after registration
                SessionHelper.SetUserSession(HttpContext.Session, user.UserID, user.Role, user.Username);
                return RedirectToDashboard();
            }

            return View(model);
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            SessionHelper.ClearSession(HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }
    }
}
