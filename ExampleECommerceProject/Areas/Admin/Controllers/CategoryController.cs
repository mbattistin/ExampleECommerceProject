using ExampleECommerceProject.Data.Contracts;
using ExampleECommerceProject.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleECommerceProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
	{
		private readonly ICategoryRepository _repository;
		public CategoryController(ICategoryRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var categoryList = _repository.GetAll();
			return View(categoryList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_repository.Add(category);
				TempData["success"] = "Category created successfully.";
				return RedirectToAction("Index");
			}
			return View(category);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id <= 0)
			{
				return NotFound();
			}
			var category = _repository.Get(c => c.Id == id);
			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_repository.Update(category);
				TempData["success"] = "Category updated successfully.";
				return RedirectToAction("Index");
			}
			return View(category);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id <= 0)
			{
				return NotFound();
			}
			var category = _repository.Get(c => c.Id == id);
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			if (id == null || id <= 0)
			{
				return NotFound();
			}
			var category = _repository.Get(c => c.Id == id);
			if (category != null)
			{
				_repository.Remove(category);
				TempData["success"] = "Category deleted successfully.";
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}
