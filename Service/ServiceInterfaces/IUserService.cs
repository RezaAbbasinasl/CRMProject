using DataTransferObject.DTOClasses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface IUserService
{
    Task<bool> LoginAsync(LoginDTO login);
    Task<bool> RegisterAsync(UserDTO userDTO);
    Task LogoutAsync(string username);
    Task<bool> UpdateAsync(EditProfileDTO userDTO, string userName);
    Task<bool> SoftDeleteAsync(Guid id);
    Task<bool> HardDeleteAsync(Guid id);
    Task<List<UserDTO>> GetAllAsync();
    Task<User> GetUser(string userName);
}
