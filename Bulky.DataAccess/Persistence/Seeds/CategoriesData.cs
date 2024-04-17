using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Persistence.Seeds
{
    public static class CategoriesData
    {
        public static List<Category> Categories { get; set; } = null!;
        public static IEnumerable<Category> Data()
        {
            Categories = new List<Category> { new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }};
            return Categories;
        }
    }
}
