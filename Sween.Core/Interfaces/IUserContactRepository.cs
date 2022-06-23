using Sween.Core.DTOs;
using Sween.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface IUserContactRepository
    {
        Task<IEnumerable<User>> MyContacts(int id);
        Task<IEnumerable<UserDTO>> Pending(int id);
        Task<IEnumerable<User>> Follow(int id);
        Task<UserContact> GetContactValidation(int p1, int p2);
        Task<bool> InsertContact(UserContact user);
        Task<bool> UpdateContact(UserContact contact);
        Task<User> GetUser(int id);
        Task<bool> DeleteContact(UserContact contact);
    }
}
