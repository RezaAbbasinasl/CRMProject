using Infrastructure;
using Infrastructure.RepositoryPattern;
using Infrastructure.RepositoryPattern.Classes;
using Infrastructure.RepositoryPattern.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service;
using Service.ServicClasses;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            MapsterConfig.RegisterMapping();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();

            builder.Services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = false;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            }).AddEntityFrameworkStores<CRMDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddDbContext<DbContext, CRMDbContext>();
            builder.Services.AddScoped<ClaimsPrincipal>();
            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Accounting/Login";
                //opt.LogoutPath = "/Accounting/Logout";
                opt.AccessDeniedPath = "/Accounting/Login";
            });
            builder.Services.AddDbContext<DbContext, CRMDbContext>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDepartementRepository, DepartementRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDepartementService, DepartementService>();

            var app = builder.Build();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}
