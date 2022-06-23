using Sween.Core.Entities;
using Sween.Core.Exceptions;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _repository;

        public UserGroupService(IUserGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> ObteinMyChats(int id)
        {
            try
            {
                var data = await _repository.GetChats(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

        public async Task<UserGroup> GetUserGroup(int group, int user)
        {
            try
            {
                var data = await _repository.GetGroup(group, user);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            
        }

        public async Task<bool> InsertUserGroup(UserGroup usergroup)
        {
            var response = new UserGroup();
            try
            {
                response = await _repository.GetGroup(usergroup.GroupId, usergroup.UserId);
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio! " + ex);
            }
            if (response == null)
            {
                try
                {
                    usergroup.CreatedBy = "ADD_TO_GROUP";
                    usergroup.CreationDate = DateTime.Now;
                    var data = await _repository.InsertGroup(usergroup);
                    return data;
                }
                catch (Exception ex)
                {
                    throw new BusinessException("Error de comunicación con el servicio! " + ex);

                }

            }
            else
            {
                throw new BusinessException("Ya perteneces a un grupo! ");
            }
            
            
        }

        public async Task<bool> DeleteUserGroup(int group, int user)
        {
            var data = await _repository.DeleteGroup(group,user);
            return data;
        }
    }
}
