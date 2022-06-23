using Sween.Core.DTOs;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<User>> MyContacts(int id);
        Task<IEnumerable<UserDTO>> Pending(int id);
        Task<IEnumerable<User>> Follow(int id);
        Task<bool> Send(UserContact contact);
        Task<bool> Accept(int id1, int id2);
        Task<bool> Reject(int id1, int id2);
        Task<bool> Unfollow(int id1, int id2);
    }
}
