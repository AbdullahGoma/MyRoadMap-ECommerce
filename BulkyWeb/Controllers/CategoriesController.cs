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
            var categoryList = _context.Categories.AsNoTracking().ToList().OrderBy(u => u.DisplayOrder);

            return View(categoryList);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {
            return PartialView("_Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = new Category { Name = model.Name, DisplayOrder = model.DisplayOrder };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return PartialView("_CategoryRow", category);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
                return NotFound();

            var viewModel = new CategoryFormViewModel
            {
                Id = id,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder
            };

            return PartialView("_Form", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _context.Categories.Find(model.Id);
            if (category is null)
                return NotFound();

            category.Name = model.Name;
            category.DisplayOrder = model.DisplayOrder;
            _context.SaveChanges();

            return PartialView("_CategoryRow", category);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if(category is null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }
        public IActionResult AllowItem(CategoryFormViewModel model)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = category is null || category.Id.Equals(model.Id);
            return Json(isAllowed);
        }

    }
}
