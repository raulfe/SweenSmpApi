using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sween.API.Response;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _repository;
        private readonly IMapper _mapper;


        public ContactsController(IContactService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de contactos para un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MyContacts")]
        public async Task<IActionResult> MyContacts([FromQuery] int id)
        {
            var data = await _repository.MyContacts(id);
            var userDTO = new List<UserDTO>();
            foreach (User e in data)
            {
                var user = new UserDTO()
                {
                    UserPublicName = e.UserPublicName,
                    UserPublicId = e.UserPublicId,
                    UserCountry = e.UserCountry,
                    UserLastName = e.UserLastName,
                    UserMidleName = e.UserMidleName,
                    UserName = e.UserName,
                    UserPhoneNumber = e.UserPhoneNumber,
                    Birthday = e.Birthday,
                    Email = e.Email,
                    Imageurl = e.Imageurl
                };

                userDTO.Add(user);

            }
            var response = new ApiResponse<IEnumerable<UserDTO>>(userDTO);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene una lista de contactos pendientes por aceptar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Pending")]
        public async Task<IActionResult> Pending([FromQuery] int id)
        {
            var data = await _repository.Pending(id);
            var response = new ApiResponse<IEnumerable<UserDTO>>(data);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene lista de follows
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Follow")]
        public async Task<IActionResult> Follow([FromQuery] int id)
        {
            var data = await _repository.Follow(id);
            var dto = new List<UserDTO>();
            foreach(User e in data)
            {
                var s = new UserDTO()
                {
                    UserCountry = e.UserCountry,
                    UserLastName = e.UserLastName,
                    UserMidleName = e.UserMidleName,
                    UserName = e.UserName,
                    UserPhoneNumber = e.UserPhoneNumber,
                    UserPublicId = e.UserPublicId,
                    UserPublicName = e.UserPublicName,
                    Birthday = e.Birthday,
                    Email = e.Email,
                    Imageurl = e.Imageurl
                };
                dto.Add(s);
            }
            var response = new ApiResponse<IEnumerable<UserDTO>>(dto);
            return Ok(response);
        }




        /// <summary>
        /// Proceso de solicitud de seguimiento a un usuario
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost("Send")]
        public async Task<IActionResult> Send(UserContact contact)
        {
            var data = await _repository.Send(contact);
            var response = new
            {
                Code = 200,
                Type = "Service response",
                Company = "Sween",
                Response = data
            };
            return Ok(response);
        }

        /// <summary>
        /// Proceso de aceptación de seguimiento a un usuario
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        [HttpPut("Accept/{id1}/{id2}")]
        public async Task<IActionResult> Accept(int id1, int id2)
        {
            var data = await _repository.Accept(id1,id2);
            var response = new
            {
                Code = 200,
                Type = "Service response",
                Company = "Sween",
                Response = data
            };
            return Ok(response);
        }

        /// <summary>
        /// Proceso de rechazo de seguimiento a un usuario
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        [HttpPut("Reject/{id1}/{id2}")]
        public async Task<IActionResult> Reject(int id1, int id2)
        {
            var data = await _repository.Reject(id1, id2);
            var response = new
            {
                Code = 200,
                Type = "Service response",
                Company = "Sween",
                Response = data
            };
            return Ok(response);
        }

        /// <summary>
        /// Proceso de unfollow  a un usuario
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        [HttpPut("Unfollow/{id1}/{id2}")]
        public async Task<IActionResult> Unfollow(int id1, int id2)
        {
            var data = await _repository.Unfollow(id1, id2);
            var response = new
            {
                Code = 200,
                Type = "Service response",
                Company = "Sween",
                Response = data
            };
            return Ok(response);
        }
    }
}
