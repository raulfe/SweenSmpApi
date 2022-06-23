using Sween.Core.Entities;
using Sween.Core.Exceptions;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
        {
            _repository = repository;
        }

       
        public async Task<Group> FindGroup(string name)
        {
            try
            {
                var data = await _repository.GetGroupName(name);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
        }

        public async Task<IEnumerable<MyGroups>> MyGroups(string nick,int id)
        {
            try
            {
                var data = await _repository.GetGroups(nick,id);
                return data;
                
                
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

        public async Task<Group> CreateGroup(Group group)
        {
            group.CreationDate = DateTime.Now;
            group.Xdate = DateTime.Now;
            group.CreatedBy = "CREATE_GROUP";

            try
            {
                var data = await _repository.InsertGroup(group);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
            
        }

        public async Task<bool> UpdateGroup(int id, string description)
        {
            try
            {
                var group = await _repository.GetGroup(id);
                group.UpdateDate = DateTime.Now;
                group.UpdatedBy = "UPDATE_GROUP";
                group.GroupDescription = description;
                var data = await _repository.UpdateGroup(group);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

        public async Task<bool> DeleteGroup(int id)
        {
            try
            {
                var data = await _repository.DeleteGroup(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }
    }
}
