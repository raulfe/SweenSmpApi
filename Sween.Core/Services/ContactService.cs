using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Exceptions;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IUserContactRepository _repository;

        public ContactService(IUserContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> MyContacts(int id)
        {
            try
            {
                var data = await _repository.MyContacts(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

        public async Task<IEnumerable<UserDTO>> Pending(int id)
        {
            try
            {
                var data = await _repository.Pending(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
        }

        public async Task<IEnumerable<User>> Follow(int id)
        {
            try
            {
                var data = await _repository.Follow(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
        }

        public async Task<bool> Send(UserContact contact)
        {
            var data = new UserContact();
            try
            {
                 data = await _repository.GetContactValidation(contact.UserPublicId, contact.UserPublicId2);
                 var d = await _repository.GetContactValidation(contact.UserPublicId2,contact.UserPublicId);
                if(d != null)
                {
                    await _repository.DeleteContact(d);
                }
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }

            if(data == null)
            {
                try
                {

                    contact.CreationDate = DateTime.Now;
                    contact.CreatedBy = "SEND";
                    contact.Status = 2;
                    var field = await _repository.InsertContact(contact);
                    return field;
                }
                catch (Exception ex)
                {

                    throw new BusinessException("Error de comunicación con el servicio! " + ex);
                }
            }
            else
            {
                try
                {
                    data.UpdateDate = DateTime.Now;
                    data.UpdatedBy = "SEND";
                    data.Status = 2;
                    var response = await _repository.UpdateContact(data);
                    return response;

                }catch(Exception ex)
                {
                    throw new BusinessException("Error de comunicación con el servicio! " + ex);
                }
            }

            
            
        }

        public async Task<bool> Accept(int id1, int id2)
        {
            var data = new UserContact();

            try
            {
                data = await _repository.GetContactValidation(id1, id2);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }

            if(data == null)
            {
                throw new BusinessException("Inconsistencia de información ");
            }

            try
            {
                data.UpdateDate = DateTime.Now;
                data.UpdatedBy = "ACCEPT";
                data.Status = 3;
                var response = await _repository.UpdateContact(data);
                return response;
            }catch(Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }

        }

        public async Task<bool> Reject(int id1, int id2)
        {
            var data = new UserContact();

            try
            {
                data = await _repository.GetContactValidation(id1, id2);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }

            if (data == null)
            {
                throw new BusinessException("Inconsistencia de información ");
            }

            try
            {
                data.UpdateDate = DateTime.Now;
                data.UpdatedBy = "REJECT";
                data.Status = 1;
                var response = await _repository.UpdateContact(data);
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
        }

        public async Task<bool> Unfollow(int id1, int id2)
        {
            var data = new UserContact();

            try
            {
                
                var d = await _repository.GetContactValidation(id2, id1);
                if(d != null)
                {
                    d.UpdateDate = DateTime.Now;
                    d.UpdatedBy = "UNFOLLOW";
                    d.Status = 1;
                    var response = await _repository.UpdateContact(d);
                    return response;
                }
                else
                {
                    data = await _repository.GetContactValidation(id1, id2);
                    if (data == null)
                    {
                        throw new BusinessException("Inconsistencia de información ");
                    }
                    else
                    {
                        data.UpdateDate = DateTime.Now;
                        data.UpdatedBy = "UNFOLLOW";
                        data.Status = 1;
                        var response = await _repository.UpdateContact(data);
                        return response;
                    }
                }

                
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
        }
    }
}
