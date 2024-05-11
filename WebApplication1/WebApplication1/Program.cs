using WebApplication1.DataAccesLayer;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MultiShopContext>();
            var app = builder.Build();

            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}" );
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Categories}/{action=Index}/{id?}" );
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.UseStaticFiles();
            app.Run();
        }
    }
}
