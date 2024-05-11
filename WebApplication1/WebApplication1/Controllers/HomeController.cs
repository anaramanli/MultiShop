using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.DataAccesLayer;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.ViewModels.CategoriesVm;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //Sqlimizi cagiririq------------------------->
        private readonly MultiShopContext _context;

        public HomeController(MultiShopContext context)
        {
            _context = context;
        }
        //-------------------------------------------->

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();

            var categories = await _context.Categories
                                            .Where(x => !x.IsDeleted)
                                            .ToListAsync();

            var homeVM = new HomeVM
            {
                Sliders = sliders,
                Categories = categories,
            };

            return View("Index", new List<HomeVM> { homeVM });
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
