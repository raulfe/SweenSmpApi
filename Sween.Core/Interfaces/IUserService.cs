using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(UsersQueryFilter filter);
        Task<User> GetUser(int id);
        Task<User> GetUserCel(string cel);
        Task<IEnumerable<User>> GetUserByNick(string nick);
        Task<bool> InsertUser(UserDTO userDTO);
        Task<bool> UpdateName(int id, string name);
        Task<bool> UpdateImage(int id, string image);
        Task<bool> DeleteUser(int id);
        Task<bool> DeleteUserPerm(int id);
    }
}
