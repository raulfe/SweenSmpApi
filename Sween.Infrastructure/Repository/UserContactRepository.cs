using Microsoft.EntityFrameworkCore;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repository
{
    public class UserContactRepository : IUserContactRepository
    {
        private readonly sweenContext _context;

        public UserContactRepository(sweenContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int id)
        {
            var data = await _context.User.FirstOrDefaultAsync(x => x.UserPublicId == id);
            return data;
        }

        public async Task<IEnumerable<User>> MyContacts(int id)
        {
            var data = await _context.UserContact.Where(x => x.UserPublicId == id && x.Status == 3 || x.UserPublicId2 == id && x.Status == 3).ToListAsync();
            var list = new List<User>();
            foreach(UserContact e in data)
            {
                if(e.UserPublicId == id)
                {
                    var us = await GetUser(e.UserPublicId2);
                    list.Add(us);

                }else if(e.UserPublicId2 == id){

                    var us = await GetUser(e.UserPublicId);
                    list.Add(us);
                }
            }
            return list;
        }

        public async Task<IEnumerable<User>> Follow(int id)
        {
            var data = new List<User>();
            var list = await _context.UserContact.Where(x => x.UserPublicId == id && x.Status == 2).ToListAsync();
            foreach(UserContact e in list)
            {
                var us = await _context.User.FirstOrDefaultAsync(x => x.UserPublicId == e.UserPublicId2);
                data.Add(us);
            }
            return data;
        }

        public async Task<IEnumerable<UserDTO>> Pending(int id)
        {
            var data = await _context.UserContact.Where(x => x.UserPublicId2 == id && x.Status == 2).ToListAsync();
            var users = new List<UserDTO>();
            foreach (UserContact e in data)
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.UserPublicId == e.UserPublicId);
                var dto = new UserDTO()
                {
                    UserPublicId = user.UserPublicId,
                    UserPublicName = user.UserPublicName,
                    UserCountry = user.UserCountry,
                    UserLastName = user.UserLastName,
                    UserMidleName = user.UserMidleName,
                    UserName = user.UserName,
                    UserPhoneNumber = user.UserPhoneNumber,
                    Birthday = user.Birthday,
                    Email = user.Email,
                    Imageurl = user.Imageurl
                };
                users.Add(dto);
            }
            return users;
        }

        public async Task<UserContact> GetContactValidation(int p1, int p2)
        {
            var data = await _context.UserContact.FirstOrDefaultAsync(x=>x.UserPublicId == p1 && x.UserPublicId2 == p2);
            return data;
        } 

        public async Task<bool> InsertContact(UserContact contact)
        {
            await _context.UserContact.AddAsync(contact);
            var response = _context.SaveChanges();
            return response > 0;

        }

        public async Task<bool> UpdateContact(UserContact contact)
        {
            _context.UserContact.Update(contact);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteContact(UserContact contact)
        {
            _context.UserContact.Remove(contact);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
       
    }
}
