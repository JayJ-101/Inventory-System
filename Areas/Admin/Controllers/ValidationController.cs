using Inventory_System.Areas.Admin.Models;
using Inventory_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private UserManager<User> _userManager;

        private Repository<Category> categoryData { get;set; }

        public ValidationController(InventorySystemDBContext ctx)
        {
            categoryData = new Repository<Category>(ctx);
        }

        public async Task<IActionResult> Check(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return Json($"Username {userName} is already taken.");
            }
            return Json(true);
        }

        public JsonResult CheckCategorty(string categoryId)
        {
            var validate = new Validate(TempData);
            validate.CheckCategory(categoryId, categoryData);
            if (validate.IsValid)
            {
                validate.MarkCategoryChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }



   
    }
}

