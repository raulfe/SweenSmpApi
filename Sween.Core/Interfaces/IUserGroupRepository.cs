using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserGroupRepository
    {
        Task<IEnumerable<User>> GetChats(int id);
        Task<UserGroup> GetGroup(int group, int user);
        Task<bool> InsertGroup(UserGroup group);
        Task<bool> UpdateGroup(UserGroup group);
        Task<bool> DeleteGroup(int group, int user);
    }
}
