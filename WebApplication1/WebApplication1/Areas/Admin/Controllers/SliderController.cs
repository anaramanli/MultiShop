using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.DataAccesLayer;
using WebApplication1.ViewModels.Sliders;

namespace WebApplication1.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController(MultiShopContext _context) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var data = await _context.Sliders
				.Where(x => !x.IsDeleted)
				.Select(s => new GetSliderVM
				{
					Id = s.Id,
					ImageUrl = s.ImageUrl,
					Subtitle = s.Subtitle,
					Title = s.Title
				}).ToListAsync();
			return View(data ?? new List<GetSliderVM>());
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateSliderVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			Sliders slider = new Sliders
			{
				IsDeleted = false,
				CreatedTime = DateTime.Now,
				Title = vm.Title,
				ImageUrl = vm.ImageUrl,
				Subtitle = vm.Subtitle
			};
			_context.Sliders.AddAsync(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task <IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			Sliders? slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
			if (slider is null) return NotFound();

			UpdateSliderVM updateSliderVM = new UpdateSliderVM
			{
				Subtitle = slider.Subtitle,
				Title = slider.Title,
				ImageUrl = slider.ImageUrl,
			};

			return View(updateSliderVM);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, UpdateSliderVM sliderVm)
		{
			if (id == null || id < 1) return BadRequest();
			Sliders existed = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == id);
			if (existed is null) return NotFound();

			existed.Title = sliderVm.Title;
			existed.ImageUrl = sliderVm.ImageUrl;
			existed.Subtitle = sliderVm.Subtitle;

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int? id,Sliders sliderToDelete)
		{
			if (id == null || id < 1) return BadRequest();
			var slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);
			if (slider is null) return NotFound();
			_context.Sliders.Remove(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");

		}
	}
}
