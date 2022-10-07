using agenceWebEF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace agenceWebEF.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly agencewebContext _context;
        public LoginController(UserManager<Utilisateur> userManager, SignInManager<Utilisateur> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") == null) HttpContext.Session.SetString("username", "Login");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Utilisateur model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.PasswordHash, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    //user role list here
                    var roles = await _userManager.GetRolesAsync(user);
                    //get default role here
                    string role = roles.FirstOrDefault();
                    if (user != null) HttpContext.Session.SetString("username", user.UserName);
                    

                    if (role.Equals("Master"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (role.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (role.Equals("User"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (role.Equals("Client"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid ID or Password");
            HttpContext.Session.SetString("username", "Login");
            return View("Login", model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Utilisateur model)
        {
            if (ModelState.IsValid)
            {
                var user = new Utilisateur
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.PasswordHash);
                if (result.Succeeded)
                {
                    //add role here
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Clients");
                }
            }
            ModelState.AddModelError("", "Invalid Register.");
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.SetString("username", "Login");
            return View();
        }

        

    }
}
