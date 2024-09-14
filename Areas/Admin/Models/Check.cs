using Inventory_System.Models;

namespace Inventory_System.Areas.Admin.Models
{
    public static  class Check
    {
        public static string UserExists(InventorySystemDBContext ctx, string userName)
        {
            string msg = string.Empty;
            if(!string.IsNullOrEmpty(userName))
            {
                var user = ctx.Users.FirstOrDefault(
                    u => u.UserName.ToLower() == userName.ToLower());
                if (user != null)
                    msg = $"Username {userName} already in use.";
              
            }
            return msg;
        }
    }
}
