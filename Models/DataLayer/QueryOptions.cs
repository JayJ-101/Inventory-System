using System.Linq.Expressions;

namespace Inventory_System.Models   
{
    public class QueryOptions<T>
    {
        // public properties for sorting and filtering
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, Object>> ThenOrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> Where { get; set; } = null!;

        private string[] includes = Array.Empty<string>();  

        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        public string[] GetIncludes() => includes;

        // read-only properties 
        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasThenOrderBy => ThenOrderBy != null;
    }
}
