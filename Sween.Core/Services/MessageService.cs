using Sween.Core.CustomEntities;
using Sween.Core.Entities;
using Sween.Core.Exceptions;
using Sween.Core.Filters;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<Message>> GetMessagesFromGroup(int id,MessageFilter filter)
        {
            try
            {
                var data = await _repository.GetMesssages(id);
                var pagedMessages =  PagedList<Message>.Create(data, filter.PageNumber, filter.PageSize);
                return pagedMessages;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

      

        public async Task<bool> InsertMessage(Message message)
        {
            try
            {
                
                message.CreatedBy = "CREATE_MSG";
                message.CreationDate = DateTime.Now;
                message.Xdate = DateTime.Now;
                
                var data = await _repository.InsertMessage(message);
                return data;

            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

       
    }
}
