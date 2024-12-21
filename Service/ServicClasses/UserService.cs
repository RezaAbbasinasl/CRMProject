using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<List<UserDTO>> GetAllAsync()
    {
        var listUser = await _userManager.Users.Select(u => u.Adapt<UserDTO>()).ToListAsync();

        if(listUser == null)
            listUser = new List<UserDTO>();

        return listUser;
    }

    public async Task<User> GetUser(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            throw new Exception("User not found.");

        return user;
    }

    public async Task<bool> HardDeleteAsync(Guid id)
    {
        var userFind = await _userManager.FindByIdAsync(id.ToString());

        if (userFind == null)
            throw new Exception("User not found.");

        var deleteResult = await _userManager.DeleteAsync(userFind);

        if (!deleteResult.Succeeded)
            throw new Exception("Error deleting user");

        return deleteResult.Succeeded;
    }

    public async Task<bool> LoginAsync(LoginDTO login)
    {
        var result = false;
        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user != null)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
            result = signInResult.Succeeded;
        }

        return result;
    }

    public async Task LogoutAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            throw new Exception("User not found.");

        await _signInManager.SignOutAsync();
    }

    public async Task<bool> RegisterAsync(UserDTO userDTO)
    {
        var duplicateUser = await _userManager.FindByNameAsync(userDTO.UserName);
        
        if (duplicateUser != null)
            throw new Exception("There is a user with this username.");

        var user = userDTO.Adapt<User>();
        user.Id = Guid.NewGuid();
        user.CreatedUserId = user.Id;
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, user.PasswordHash);
        var registerResult = await _userManager.CreateAsync(user,userDTO.Password);

        if (!registerResult.Succeeded)
            throw new Exception("");

        return registerResult.Succeeded;
    }

    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        var userFind = await _userManager.FindByIdAsync(id.ToString());

        if (userFind == null)
            throw new Exception("User not found.");

        userFind.IsActive = false;
        
        return await UpdateAsync(userFind.Adapt<EditProfileDTO>(),userFind.UserName);
    }

    public async Task<bool> UpdateAsync(EditProfileDTO userDTO , string userName)
    {
        var userFind = await _userManager.FindByNameAsync(userName);

        if (userFind == null)
            throw new Exception("User not found.");

        userFind.UpdatedUserId = userFind.Id;
        userFind.PhoneNumber = userDTO.Phone;
        userFind.FirstName = userDTO.FirstName;
        userFind.LastName = userDTO.LastName;
        userFind.Email = userDTO.Email;

        var updateResult = await _userManager.UpdateAsync(userFind);

        if (!updateResult.Succeeded)
            throw new Exception("User update failed");

        return updateResult.Succeeded;
    }
}
