using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Exceptions;
using Sween.Core.Interfaces;
using Sween.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<User>> GetUsers(UsersQueryFilter filter)
        {
            try
            {
                var data = await _repository.GetUsers();

                if (filter.UserPublicId != null)
                {
                    data = data.ToList().Where(x => x.UserPublicId == filter.UserPublicId);
                }
                if (filter.UserName != null)
                {
                    data = data.ToList().Where(x => x.UserName == filter.UserName);
                }
                if (filter.UserPhoneNumber != null)
                {
                    data = data.ToList().Where(x => x.UserPhoneNumber == filter.UserPhoneNumber);
                }
                if (filter.UserPublicName != null)
                {
                    data = data.ToList().Where(x => x.UserPublicName == filter.UserPublicName);
                }
                if(data == null)
                {
                    throw new BusinessException("No existen campos en el servidor!");
                }

                return data;
            }catch(Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio!");
            }
            

        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var data = await _repository.GetUser(id);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }
            
        }

        public async Task<User> GetUserCel(string cel)
        {
            try
            {
                var data = await _repository.GetUserCel(cel);
                return data;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }

        }

        public async Task<IEnumerable<User>> GetUserByNick(string nick)
        {
            try
            {
                var data = await _repository.GetUserForNick(nick);
                return data;
            }
            catch (Exception e)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }
            
        }

        public async Task<bool> InsertUser(UserDTO userDTO)
        {
            var user = new User() 
            {
                UserPublicName = userDTO.UserPublicName,
                UserName = userDTO.UserName,
                UserLastName = userDTO.UserLastName,
                UserPhoneNumber = userDTO.UserPhoneNumber,
                UserCountry = userDTO.UserCountry,
                Email = userDTO.Email,
                Birthday = userDTO.Birthday,
                Imageurl = userDTO.Imageurl
            };
            var time = Convert.ToDateTime("2008-01-01");
            user.UserThemeId = 1;
            user.Status = "1";
            user.ActiveDate = DateTime.Now;
            user.CreationDate = DateTime.Now;
            user.CreatedBy = "APIService";

            #region Validations
            if (Convert.ToDateTime(user.Birthday) > time)
            {
                throw new BusinessException("Parece que tu rango de edad no es permitido");
            }
            var validation = await _repository.FindUser(user.UserPublicName);
                if (validation != null)
            {
                throw new BusinessException("El usuario ya existe!");
            }
            #endregion

            try
            {
                var data = await _repository.InsertUser(user);
                return data;
            }
            catch (Exception e)
            {

                throw new BusinessException($"Error de comunicación con el servicio! {e.Message}");
            }
                

           
            
        }

        public async Task<bool> UpdateName(int id, string name)
        {
            var user = new User();
            try
            {
                user = await _repository.GetUser(id);
                if (user == null)
                {
                    throw new BusinessException("Usuario no identificado");
                }
            }
            catch (Exception)
            {

                throw new BusinessException("Usuario no identificado");
            }
            

            user.UpdateDate = DateTime.Now;
            user.UpdatedBy = "UPDATE_USER";
            user.UserName = name;
            try
            {
                var data = await _repository.UpdateUser(user);
                return data;
            }
            catch (Exception)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }
            
        }

        public async Task<bool> UpdateImage(int id, string image)
        {
            var user = new User();
            try
            {
                user = await _repository.GetUser(id);
                if(user == null)
                {
                    throw new BusinessException("Usuario no identificado");
                }
            }
            catch (Exception)
            {

                throw new BusinessException("Usuario no identificado");
            }


            user.UpdateDate = DateTime.Now;
            user.UpdatedBy = "UPDATE_USER";
            user.Imageurl = image;
            try
            {
                var data = await _repository.UpdateUser(user);
                return data;
            }
            catch (Exception)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = new User();
            try
            {
                 user = await _repository.GetUser(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error de comunicación con el servicio!");
            }

            user.Status = "0";
            user.InactiveDate = DateTime.Now;

            try
            {
                var data = await _repository.UpdateUser(user);
                return data;
            }
            catch (Exception)
            {
                throw new BusinessException("Error de comunicación con el servicio!");
            }
            
        }

        public async Task<bool> DeleteUserPerm(int id)
        {
            try
            {
                var response = await _repository.DeleteUser(id);
                return response;
            }
            catch (Exception)
            {

                throw new BusinessException("Error de comunicación con el servicio!");
            }
        }

    }
}
