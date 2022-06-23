using Sween.Core.CustomEntities;
using Sween.Core.Entities;
using Sween.Core.Filters;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IMessageService
    {
        Task<PagedList<Message>> GetMessagesFromGroup(int id, MessageFilter filter);
        Task<bool> InsertMessage(Message message);
    }
}
