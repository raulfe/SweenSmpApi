using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> GetGroupName(string name);
        Task<Group> GetGroup(int id);
        Task<IEnumerable<MyGroups>> GetGroups(string nick, int id);
        Task<Group> InsertGroup(Group group);
        Task<bool> UpdateGroup(Group group);
        Task<bool> DeleteGroup(int id);
    }
}
