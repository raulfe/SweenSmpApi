using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMesssages(int id);
        Task<Message> GetMessage(int id);
        Task<bool> InsertMessage(Message message);
        Task<bool> UpdateMessage(Message message);
        Task<bool> DeleteMessage(int id);
    }
}
