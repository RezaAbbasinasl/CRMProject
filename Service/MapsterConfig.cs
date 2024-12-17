using DataTransferObject.DTOClasses;
using Mapster;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class MapsterConfig
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<UserDTO, User>.NewConfig()
                .Map(u => u.PhoneNumber, u => u.Phone)                
                .Map(u => u.NormalizedUserName, u => u.UserName)
                .Map(u => u.NormalizedEmail, u => u.Email)
                .Map(u => u.PasswordHash, u => u.Password);
            TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
                .Map(c => c.CreatedUserId, c => c.CreateUserId);            
        }
    }
}
