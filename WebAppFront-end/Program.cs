using WebApp.Services.Http;

namespace WebAppFront_end
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Definine el cliente HTTP para consumir la API
            builder.Services.AddHttpClient("Api", c => c.BaseAddress = new Uri("https://localhost:7027/"));

            // Definine el cliente HTTP para consumir la Map de Google
            // builder.Services.AddHttpClient("GoogleMaps", c => c.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/"));
            // SESSION
            //builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();


            // Registrar auxiliar http (síncrono simple)
            builder.Services.AddScoped<AuxiliarClienteHttp>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
