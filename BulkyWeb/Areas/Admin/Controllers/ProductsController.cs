using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var productList = _unitOfWork.Products.GetAll();
            var viewModel = _mapper.Map<IEnumerable<ProductViewModel>>(productList);
            return View(viewModel);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = _mapper.Map<Product>(model);

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return PartialView(viewModel);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product is null)
                return NotFound();

            var viewModel = _mapper.Map<ProductFormViewModel>(product);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = _unitOfWork.Products.GetById(model.Id);
            if (product is null)
                return NotFound();

            product = _mapper.Map(model, product);
            _unitOfWork.Complete();

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return View(viewModel);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product is null)
                return NotFound();

            _unitOfWork.Products.Remove(product);
            _unitOfWork.Complete();

            return Ok();
        }
        public IActionResult AllowItem(ProductFormViewModel model)
        {
            var Product = _unitOfWork.Products.Find(c => c.Title == model.Title || c.ISBN == model.ISBN);
            var isAllowed = Product is null || Product.Id.Equals(model.Id);
            return Json(isAllowed);
        }

    }
}
