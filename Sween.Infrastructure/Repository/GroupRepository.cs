using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly sweenContext _context;

        public GroupRepository(sweenContext context)
        {
            _context = context;
        }

        public async Task<Group> GetGroupName(string name)
        {
            var data = await _context.Group.FirstOrDefaultAsync(x => x.GroupDescription == name);
            return data;
        }

        public async Task<Group> GetGroup(int id)
        {
            var data = await _context.Group.FirstOrDefaultAsync(x => x.GroupId == id);
            return data;
        }

        public async Task<IEnumerable<MyGroups>> GetGroups(string nick,int id)
        {
            var data = await _context.Group.Where(x => x.Xuser == nick).ToListAsync();
            var list = new List<MyGroups>();
            foreach(Group g in data)
            {
                var second = await _context.UserGroup.FirstOrDefaultAsync(x => x.GroupId == g.GroupId && x.UserId != id);
                if(second != null)
                {
                    var item = new MyGroups()
                    {
                        GroupDescription = g.GroupDescription,
                        GroupId = g.GroupId,
                        GroupType = g.GroupType,
                        User1 = id,
                        User2 = second.UserId
                    };
                    list.Add(item);
                }
                
            }
            return list;
        }

        public async Task<Group> InsertGroup(Group group)
        {
            await _context.Group.AddAsync(group);
            _context.SaveChanges();
            var response = await GetGroupName(group.GroupDescription);
            return response;
        }

        public async Task<bool> UpdateGroup(Group group)
        {
            _context.Group.Update(group);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteGroup(int id)
        {
            var data = await GetGroup(id);
            _context.Group.Remove(data);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
