using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccesLayer;
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
            var data = await _context.Categories.Where(x => x.IsDeleted == false)
                .Select(x => new GetCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            return View(data);
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
