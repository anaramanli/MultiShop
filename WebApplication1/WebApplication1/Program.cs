namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            app.UseStaticFiles();
            app.Run();
        }
    }
}
