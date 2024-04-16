using Bulky.DataAccess.Persistence.Repositories.IRepository;
using Bulky.Models.Entities;

namespace BulkyWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categoryList = _unitOfWork.Categories.GetAll().OrderBy(u => u.DisplayOrder);
            var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryList);
            return View(viewModel);
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

            var category = _mapper.Map<Category>(model);

            _unitOfWork.Categories.Add(category);
            _unitOfWork.Complete();

            var viewModel = _mapper.Map<CategoryViewModel>(category);

            return PartialView("_CategoryRow", viewModel);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category is null)
                return NotFound();

            var viewModel = _mapper.Map<CategoryFormViewModel>(category);

            return PartialView("_Form", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _unitOfWork.Categories.GetById(model.Id);
            if (category is null)
                return NotFound();

            category = _mapper.Map(model, category);
            _unitOfWork.Complete();

            var viewModel = _mapper.Map<CategoryViewModel>(category);

            return PartialView("_CategoryRow", viewModel);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if(category is null)
                return NotFound();

            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Complete();

            return Ok();
        }
        public IActionResult AllowItem(CategoryFormViewModel model)
        {
            var category = _unitOfWork.Categories.Find(c => c.Name == model.Name);
            var isAllowed = category is null || category.Id.Equals(model.Id);
            return Json(isAllowed);
        }

    }
}
