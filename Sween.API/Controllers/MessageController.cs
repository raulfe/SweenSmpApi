using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sween.API.Response;
using Sween.Core.CustomEntities;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Filters;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<ChatHubs> _hub;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public MessageController(IMessageService repository, IMapper mapper, IConfiguration configuration, IHubContext<ChatHubs> hub, IBackgroundJobClient backgroundJobClient)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
            _hub = hub;
            _backgroundJobClient = backgroundJobClient;
        }

        /// <summary>
        /// Obtiene los mensajes filtrados mediante el parametro del ID del grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("FromGroup")]
        public async Task<IActionResult> GetMessagesFromGroup([FromQuery]int id,[FromQuery] int pageNumber)
        {
            var pageSize = _configuration["Pagination:PageSize"];
            var filter = new MessageFilter()
            {
                PageNumber = pageNumber,
                PageSize = Convert.ToInt32(pageSize)
            };
            var data = await _repository.GetMessagesFromGroup(id,filter);
            var dataDTO = _mapper.Map<IEnumerable<MessageDTO>>(data);
            var metadata = new Metadata
            {
                TotalCount = data.TotalCount,
                PageSize =  data.PageSize,
                CurrentPage =  data.CurrentPage,
                TotalPages =  data.TotalPages,
                HasNextPage = data.HasNextPage,
                HasPreviousPage= data.HasPreviousPage
            };
            var response = new ApiResponse<IEnumerable<MessageDTO>>(dataDTO)
            {
                Meta = metadata
            };
            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }




        /// <summary>
        /// Inserta un mensaje configurado
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageBlobDTO message)
        {
            if (message.MessageBlob != null)
            {
                var msg = new Message()
                {
                    BlobType = message.BlobType,
                    CreatedBy = message.CreatedBy,
                    CreationDate = message.CreationDate,
                    GroupId = message.GroupId,
                    Message1 = message.Message1,
                    MessageBlob = message.MessageBlob,
                    MessageId = message.MessageId,
                    UpdateDate = message.UpdateDate,
                    UpdatedBy = message.UpdatedBy,
                    UserId = message.UserId,
                    Xdate = message.Xdate,
                    Xuser = message.Xuser
                };
                _backgroundJobClient.Enqueue<IMessageService>(res => res.InsertMessage(msg));
                return Ok();
            }
            else
            {
                var msg = new Message()
                {
                    CreatedBy = message.CreatedBy,
                    CreationDate = message.CreationDate,
                    GroupId = message.GroupId,
                    Message1 = message.Message1,
                    MessageId = message.MessageId,
                    UpdateDate = message.UpdateDate,
                    UpdatedBy = message.UpdatedBy,
                    UserId = message.UserId,
                    Xdate = message.Xdate,
                    Xuser = message.Xuser
                };
                _backgroundJobClient.Enqueue<IMessageService>(res => res.InsertMessage(msg));
                await _hub.Clients.Group(message.GroupId.ToString()).SendAsync("Receive", message.Xuser, message.Message1);
                
                return Ok();
            }
            
            
            
        }


        
    }
}
