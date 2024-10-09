using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace Inventory_System.Models
{
    public class Validate
    {
        //private const for woring TempData
        private const string CategoryKey = "validCategory";
        


        //constructor and private TempData property
        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        //public  properties
        public bool IsValid { get;private set; }
        public string ErrorMessage { get; private set; } =string.Empty;


        public void CheckCategory(string categoryName, Repository<Category> data)
        {
            Category? entity = data.Get(categoryName);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Category already exist";
        }
        public void MarkCategoryChecked() => tempData[CategoryKey] = true;
        public void ClearCategory() => tempData.Remove(CategoryKey);
        public bool IsCategrychecked => tempData.Keys.Contains(CategoryKey);
    }
}
