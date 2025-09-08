using Microsoft.EntityFrameworkCore;
using MVC_Assignment3_BLL.Services;
using MVC_Assignment3_DAL.Context;
using MVC_Assignment3_DAL.Repositories;
using MVC_Assignment3_PL.Controllers;

namespace MVC_Assignment3_PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            #region Dependency Injection(Add Services)
            builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            //builder.Services.AddScoped<CompanyDBContext>();
            builder.Services.AddDbContext<CompanyDBContext>(option =>
            {
                var Connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
                option.UseSqlServer(Connectionstring); // Connection String
            });
            var app = builder.Build();
            #endregion
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseRouting();

            //app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
