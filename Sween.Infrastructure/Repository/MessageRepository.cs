using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly sweenContext _context;

        public MessageRepository(sweenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMesssages(int id)
        {
            var data = await _context.Message.Where(x => x.GroupId == id).OrderByDescending(x => x.CreationDate).ToListAsync();
            return data;
        }

        public async Task<Message> GetMessage(int id)
        {
            var data = await _context.Message.FirstOrDefaultAsync(x=>x.MessageId == id);
            return data;
        }

        public async Task<bool> InsertMessage(Message message)
        {
            await _context.Message.AddAsync(message);
            var response = _context.SaveChanges();
            return response > 0;
        }

        public async Task<bool> UpdateMessage(Message message)
        {
            _context.Message.Update(message);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<bool> DeleteMessage(int id)
        {
            var data = await GetMessage(id);
            _context.Message.Remove(data);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
