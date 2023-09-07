using ExampleECommerceProject.Data.Contracts;
using ExampleECommerceProject.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleECommerceProject.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
        private readonly IProductRepository _repository;

		public ProductController(IProductRepository repository)
		{
			_repository = repository;
		}
        public IActionResult Index()
        {
            var productList = _repository.GetAll();
            return View(productList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var product = _repository.Get(c => c.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var product = _repository.Get(c => c.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var product = _repository.Get(c => c.Id == id);
            if (product != null)
            {
                _repository.Remove(product);
                TempData["success"] = "Product deleted successfully.";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}

