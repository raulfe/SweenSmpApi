using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly sweenContext _context;

        public UserGroupRepository(sweenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetChats(int id)
        {
            var chats = new List<User>();
            var data = await _context.UserGroup.Where(x=>x.UserId == id).ToListAsync();
            foreach (UserGroup u in data)
            {
                var item = await _context.UserGroup.FirstOrDefaultAsync(x => x.GroupId == u.GroupId && x.UserId != u.UserId);
                if(item != null)
                {
                    var chat = await _context.User.FirstOrDefaultAsync(x => x.UserId == item.UserId);
                    if(chat != null)
                    {
                        chats.Add(chat);
                    }
                }

            }
            return chats;
        }

        public async Task<UserGroup> GetGroup(int group, int user)
        {
            var data = await _context.UserGroup.FirstOrDefaultAsync(x => x.GroupId == group && x.UserId == user);
            return data;
        }


        public async Task<bool> InsertGroup(UserGroup group)
        {
            await _context.UserGroup.AddAsync(group);
            var response =_context.SaveChanges();
            return response > 0;
        }

        public async Task<bool> UpdateGroup(UserGroup group)
        {
            _context.UserGroup.Update(group);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteGroup(int group, int user)
        {
            var data = await GetGroup(group,user);
            _context.UserGroup.Remove(data);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
