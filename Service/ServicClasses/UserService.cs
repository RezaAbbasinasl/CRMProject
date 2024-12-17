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

    public async Task<User> GetUser(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
            throw new Exception("");

        return user;
    }

    public async Task<bool> HardDeleteAsync(Guid id)
    {
        var userFind = await _userManager.FindByIdAsync(id.ToString());

        if (userFind == null)
            throw new Exception("");

        var deleteResult = await _userManager.DeleteAsync(userFind);

        if (!deleteResult.Succeeded)
            throw new Exception("");

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
            throw new Exception("");

        await _signInManager.SignOutAsync();
    }

    public async Task<bool> RegisterAsync(UserDTO userDTO)
    {
        var duplicateUser = await _userManager.FindByNameAsync(userDTO.UserName);
        
        if (duplicateUser != null)
            throw new Exception("");

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
            throw new Exception("");

        userFind.IsActive = false;
        
        return await UpdateAsync(userFind.Adapt<UserDTO>());
    }

    public async Task<bool> UpdateAsync(UserDTO userDTO)
    {
        var userFind = await _userManager.FindByNameAsync(userDTO.UserName);

        if (userFind == null)
            throw new Exception("");

        var user = userDTO.Adapt<User>();
        var updateResult = await _userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
            throw new Exception("");

        return updateResult.Succeeded;
    }
}
