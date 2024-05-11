using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.DataAccesLayer;
using WebApplication1.Models;
using WebApplication1.ViewModels.CategoriesVm;
using WebApplication1.ViewModels.Sliders;

namespace WebApplication1.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoriesController(MultiShopContext _context) : Controller
	{
		
		public async Task<IActionResult> Index()
		{
			var data = await _context.Categories
				.Where(x => !x.IsDeleted)
				.Select(s => new GetCategoryVM
				{
					Id = s.Id,
					Name = s.Name,
					
				}).ToListAsync();
			return View(data ?? new List<GetCategoryVM>());
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoriesVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			Category category = new Category
			{
				IsDeleted = false,
				CreatedTime = DateTime.Now,
				Name = vm.Name
			};
			_context.Categories.AddAsync(category);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			Category? category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
			if (category is null) return NotFound();

			UpdateCategoryVm updateCategoryVM = new UpdateCategoryVm
			{
				Name = category.Name,
			};

			return View(updateCategoryVM);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, UpdateCategoryVm sliderVm)
		{
			if (id == null || id < 1) return BadRequest();
			Category existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (existed is null) return NotFound();

			existed.Name = sliderVm.Name;
			
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int? id, Category categoryToDelete)
		{
			if (id == null || id < 1) return BadRequest();
			var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (category is null) return NotFound();
			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");

		}
	}
}
