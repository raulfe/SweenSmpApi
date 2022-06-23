using Sween.Core.Entities;
using Sween.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IGroupService
    {
        Task<Group> FindGroup(string name);
        Task<IEnumerable<MyGroups>> MyGroups(string nick, int id);
        Task<Group> CreateGroup(Group group);
        Task<bool> UpdateGroup(int id, string description);
        Task<bool> DeleteGroup(int id);
    }
}
