using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objCategoryList = _context.Categories.ToList().OrderBy(u => u.DisplayOrder);

            return View(objCategoryList);
        }
    }
}
