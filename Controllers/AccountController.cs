
using Inventory_System.Models;  
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]   
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var result =await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");   
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }

            }
            return View(model);
        }

    }

}
