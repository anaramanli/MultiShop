using WebApplication1.Models;
namespace WebApplication1.Areas.Admin.Models;

public class HomeVM
{
    public List<Sliders> Sliders { get; set; }
    public List<Category> Categories { get; set; }
}
