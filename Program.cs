using _2point3_Cloud.Data;
using Microsoft.EntityFrameworkCore;

namespace _2point3_Cloud;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection"))
        );
        var app = builder.Build();

        // Apply migrations on app start
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        db.Database.Migrate();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}