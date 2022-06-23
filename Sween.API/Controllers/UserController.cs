using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Sween.API.Response;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///Controlador vinculado a los servicios por Usuario
    public class UserController : ControllerBase
    {
        private readonly IUserService _repository;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public UserController(IUserService repository, IMapper mapper, IBackgroundJobClient backgroundJobClient)
        {
            _repository = repository;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
        }
        /// <summary>
        /// Instancia que permite la obtención en forma de una Lista de los usuarios almacenados
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetUsers([FromQuery] UsersQueryFilter filter)
        {
            var data = await _repository.GetUsers(filter);
            var dataDTO = _mapper.Map<IEnumerable<UserDTO>>(data);
            var response = new ApiResponse<IEnumerable<UserDTO>>(dataDTO);
            return Ok(response);
        }

        /// <summary>
        /// Instancia que permite la obtención de un usuario bajo el parametro de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Id")]
        public async Task<IActionResult> GetUser([FromQuery] int id)
        {
            var data = await _repository.GetUser(id);
            var dataDTO = _mapper.Map<UserDTO>(data);
            var response = new ApiResponse<UserDTO>(dataDTO);
            return Ok(response);
        }

        /// <summary>
        /// Instancia que permite la obtención de un usuario bajo el parametro de su PhoneNumber
        /// </summary>
        /// <param name="cel"></param>
        /// <returns></returns>
        [HttpGet("Cel")]
        public async Task<IActionResult> GetUserCel([FromQuery] string cel)
        {
            var data = await _repository.GetUserCel(cel);
            if(data == null)
            {
                var response = new ApiResponse<User>(data);
                return Ok(response);
            }
            else
            {
                var DTO = new UserDTO()
                {
                    UserPublicId = data.UserPublicId,
                    UserPublicName = data.UserPublicName,
                    UserCountry = data.UserCountry,
                    UserLastName = data.UserLastName,
                    UserName = data.UserName,
                    UserPhoneNumber = data.UserPhoneNumber,
                    Email = data.Email,
                    Birthday = data.Birthday,
                    Imageurl = data.Imageurl
                };
                return Ok(DTO);
            }
            
            
        }

        /// <summary>
        /// Instancia permite la obtención de un usuario bajo el parametro de su NickName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Nick")]
        public async Task<IActionResult> GetUserForNick([FromQuery] string nick)
        {
            var data = await _repository.GetUserByNick(nick);
            var list = new List<UserDTO>();
            foreach(User e in data)
            {
                var user = new UserDTO()
                {
                    UserPublicId = e.UserPublicId,
                    UserCountry = e.UserCountry,
                    UserLastName = e.UserLastName,
                    UserMidleName = e.UserMidleName,
                    UserName = e.UserName,
                    UserPhoneNumber = e.UserPhoneNumber,
                    UserPublicName = e.UserPublicName,
                    Birthday = e.Birthday,
                    Email = e.Email,
                    Imageurl = e.Imageurl
                };
                list.Add(user);
            }
            var response = new ApiResponse<IEnumerable<UserDTO>>(list);
            return Ok(response);
        }

       


        /// <summary>
        /// Instancia que permite la inserción de usuario mediante un JSON estructurado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertUser(UserDTO user)
        {
            var data = await _repository.InsertUser(user);
            var response = new
            {
                Code=200,
                Type="Service response",
                Company="Sween",
                Response=data
            };
            return Ok(response);
        }


        /// <summary>
        /// Etapa de actualización del usuario //Nombre
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("Name")]
        public async Task<IActionResult> UpdateUser(int id, string name)
        {
            var data = await _repository.UpdateName(id,name);
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
        /// Etapa de actualización del usuario //Imagen
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("Image")]
        public async Task<IActionResult> UpdateImage(int id, string image)
        {
            var data = await _repository.UpdateImage(id, image);
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
        /// Inactivación de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            var data = await _repository.DeleteUser(id);
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
        /// Eliminación permanente de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUserPerm([FromQuery] int id)
        {
            var data = await _repository.DeleteUserPerm(id);
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
