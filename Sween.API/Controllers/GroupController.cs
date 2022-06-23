using AutoMapper;
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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _repository;
        private readonly IMapper _mapper;

        public GroupController(IGroupService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       

        /// <summary>
        /// Obtencion de lista de grupos basado en un arreglo de id's de tus grupos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MyGroups")]
        public async Task<IActionResult> MyGroups([FromQuery] string nick,int id)
        {
            var data = await _repository.MyGroups(nick,id);
            var response = new
            {
                data = data
            };
            return Ok(response);
        }

        /// <summary>
        /// Creación de un nuevo grupo
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertGroup(Group group)
        {
            var data = await _repository.CreateGroup(group);
            return Ok(data);
        }


        /// <summary>
        /// Actualización de descripcion de Grupo
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGroup(int id, string description)
        {
            var data = await _repository.UpdateGroup(id,description);
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
        /// Eliminacion permanente de grupos
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(int group)
        {
            var data = await _repository.DeleteGroup(group);
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
