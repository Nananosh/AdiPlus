using System.Threading.Tasks;
using AdiPlus.Migrations;
using AdiPlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public RolesController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext context, RoleManager<IdentityRole> roleManager)
        {
            _database = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Doctor"));
            await _roleManager.CreateAsync(new IdentityRole("Patient"));
            return RedirectToAction("Index","Home");
        }

        public void GivePatientRole(User user)
        {
            // var patientRole = _roleManager.Roles.Where(r => r.Name == "Patient");
            _userManager.AddToRoleAsync(user, "Patient");
        }
    }
}