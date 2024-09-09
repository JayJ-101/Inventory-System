
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
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LogInVM {  ReturnUrl = returnURL };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM model)
        {
            if (ModelState.IsValid)
            {
               
                var result = await signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    //get logged in User
                    var user = await userManager.FindByNameAsync(model.UserName);

                    //If the ReturnUrl is valid and local, redirect to it
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl)) {
                        return Redirect(model.ReturnUrl);
                    }
                   
                    if (await userManager.IsInRoleAsync(user, "Admin"))
                    { 
                        return RedirectToAction("Index", "User", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }
    }

}
