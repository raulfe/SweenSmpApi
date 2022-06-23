using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly sweenContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(sweenContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var data =  await _context.User.ToListAsync(); 
            return data;
        }

        public async Task<User> GetUser(int id)
        {
            var data =  await _context.User.FirstOrDefaultAsync(x => x.UserPublicId == id);
            return data;
        }

        public async Task<User> GetUserCel(string cel)
        {
            var data = await _context.User.FirstOrDefaultAsync(x => x.UserPhoneNumber == cel);
            return data;
        }

        public async Task<IEnumerable<User>> GetUserForNick(string nick)
        {
            
            if(nick == null)
            {
                 var d = await _context.User.ToListAsync();
                return d;
            }
            else
            {
                var data = await _context.User.Where(x => x.UserPublicName.StartsWith(nick)).ToListAsync();
                return data;
            }
            
        }

        public async Task<User> FindUser(string nick)
        {
            var data = await _context.User.FirstOrDefaultAsync(x=>x.UserPublicName == nick);
            return data;
        }

        public async Task<bool> InsertUser(User user)
        {
            _context.User.Add(user);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.User.Update(user);
            var request = await _context.SaveChangesAsync();
            return request > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var data = await GetUser(id);
            _context.User.Remove(data);
            var request = await _context.SaveChangesAsync();
            return request > 0;
        }
    }
}
