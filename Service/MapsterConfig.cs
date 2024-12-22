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
                .Map(u => u.PasswordHash, u => u.Password)
                .Map(u => u.CreatedUserId, u => u.CreateUserId);
            TypeAdapterConfig<User, UserDTO>.NewConfig()
                .Map(u => u.CreateUserId, u => u.CreatedUserId)
                .Map(u => u.Phone, u => u.PhoneNumber);
            TypeAdapterConfig<User, EditProfileDTO>.NewConfig()
                .Map(u => u.Phone, u => u.PhoneNumber);                

            TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
                .Map(c => c.CreatedUserId, c => c.CreateUserId);
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                .Map(c => c.CreateUserId, c => c.CreatedUserId);

            TypeAdapterConfig<RoleDTO, Role>.NewConfig()
                .Map(c => c.CreatedUserId, c => c.CreateUserId);
            TypeAdapterConfig<Role, RoleDTO>.NewConfig()
                .Map(c => c.CreateUserId, c => c.CreatedUserId);

            TypeAdapterConfig<TicketDTO, Ticket>.NewConfig()
                .Map(c => c.CreatedUserId, c => c.CreateUserId);
            TypeAdapterConfig<Ticket, TicketDTO>.NewConfig()
                .Map(c => c.CreateUserId, c => c.CreatedUserId);

            TypeAdapterConfig<Message, MessageDTO>.NewConfig()
                .Map(c => c.CreateUserId, c => c.CreatedUserId);
            TypeAdapterConfig<MessageDTO, Message>.NewConfig()
                .Map(c => c.CreatedUserId, c => c.CreateUserId);
        }
    }
}
