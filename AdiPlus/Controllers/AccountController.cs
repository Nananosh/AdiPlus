using System.Threading.Tasks;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels;
using AdiPlus.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext context)
        {
            _database = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult RegisterDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email, UserName = model.UserName,
                    UserImage = "https://img.icons8.com/material-outlined/200/000000/user--v1.png"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _database.Doctors.AddAsync(new Doctor
                    {
                        User = user,
                        Name = model.Name,
                        Surname = model.Surname,
                        LastName = model.Lastname
                    });
                    await _database.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user, "Doctor");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email, UserName = model.UserName,
                    UserImage = "https://img.icons8.com/material-outlined/200/000000/user--v1.png"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _database.Clients.AddAsync(new Client
                    {
                        User = user,
                        Name = model.Name,
                        Surname = model.Surname,
                        LastName = model.Lastname,
                        DateBirth = model.DateBirth,
                    });
                    await _database.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user, "Patient");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager
                    .PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);

                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}