using Inventory_System.Areas.Admin.Models;
using Inventory_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.Areas.Admin.Controllers
{
    public class ValidationController : Controller
    {
        private UserManager<User> _userManager;
        public async Task<IActionResult> Check(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return Json($"Username {userName} is already taken.");
            }
            return Json(true);
        }
    }
}

