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
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _repository;
        private readonly IMapper _mapper;   
        public UserGroupController(IUserGroupService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene todos los grupos del usuario mediante el paramentro del ID de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MyChats")]
        public async Task<IActionResult> MyGroups(int id)
        {
            var data = await _repository.ObteinMyChats(id);
            var dataDTO = _mapper.Map<IEnumerable<UserGroupDTO>>(data);
            var response = new ApiResponse<IEnumerable<UserGroupDTO>>(dataDTO);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un solo grupo mediante los parametros del ID de grupo y ID de usuario
        /// </summary>
        /// <param name="group"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("Group")]
        public async Task<IActionResult> GetGroup([FromQuery] int group, int user)
        {
            var data = await _repository.GetUserGroup(group, user);
            var dataDTO = _mapper.Map<UserGroupDTO>(data);
            var response = new ApiResponse<UserGroupDTO>(dataDTO);
            return Ok(response);
        }


        /// <summary>
        /// Inserta un grupo nuevo configurado
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddtoGroup(UserGroup group)
        {
            var data = await _repository.InsertUserGroup(group);
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
        /// Borra permanentemente la instancia de grupo seleccionada
        /// </summary>
        /// <param name="group"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(int group, int user)
        {
            var data = await _repository.DeleteUserGroup(group,user);
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
