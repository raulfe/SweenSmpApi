using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserGroupService
    {
        Task<IEnumerable<User>> ObteinMyChats(int id);
        Task<UserGroup> GetUserGroup(int group, int user);
        Task<bool> InsertUserGroup(UserGroup usergroup);
        Task<bool> DeleteUserGroup(int group, int user);
    }
}
