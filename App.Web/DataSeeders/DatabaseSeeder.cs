using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace App.Web.DataSeeders;

public class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>(); 
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
       
        var adminUser = new UserDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "admin",
            LastName = "admin",
            Email = "admin@gmail.com",
            UserName = "admin",
            Password = "@dmin12345678",
            Phone = "1234567890",
        };
        adminUser.CreateUserId = adminUser.Id;        
        var user = adminUser.Adapt<User>();
        user.PasswordHash = userManager.PasswordHasher.HashPassword(user, adminUser.Password);

        var currentUser = await userManager.FindByNameAsync(user.UserName!);
        if(currentUser == null) 
            await userManager.CreateAsync(user);

        var roles = new List<Role>()
        {
            new Role{ Name = "Admin", CreatedUserId = user.Id, Id = Guid.NewGuid() }
        };

        foreach (var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role.Name!))
                await roleManager.CreateAsync(role);
        }


        currentUser = await userManager.FindByNameAsync(user.UserName!);

        if (!await userManager.IsInRoleAsync(currentUser!, "Admin"))
            await userManager.AddToRoleAsync(currentUser!, "Admin");
    }
}
