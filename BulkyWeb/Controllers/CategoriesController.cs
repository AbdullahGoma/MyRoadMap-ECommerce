using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BulkyWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objCategoryList = _context.Categories.ToList().OrderBy(u => u.DisplayOrder);

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
