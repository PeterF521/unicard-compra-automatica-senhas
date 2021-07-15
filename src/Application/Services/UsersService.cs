using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCAR.Domain.Entities;
using UCAR.Domain.InputDTOs;
using UCAR.Domain.Interfaces.Services;
using UCAR.Domain.Interfaces.Repositories;
using UCAR.Domain.Exceptions;

namespace UCAR.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> CheckCredentials(CheckUserCredentialsInputDTO credentials)
        {
            User foundUser = await _usersRepository.FindUserByEmail(credentials.Email);
            if(foundUser == null)
            {
                return false;    
            }

            return foundUser.Password == credentials.Password;
        }

        public async Task<User> CreateUser(CreateUserInputDTO user)
        {
            User foundUser = await _usersRepository.FindUserByEmail(user.Email);
            if(foundUser != null)
            {
                throw new UserAlreadyRegisteredException(foundUser);
            }

            User userToSave = new()
            {
                Name = user.Name,
                EducatorEmail = user.EducatorEmail,
                Email = user.Email,
                Password = user.Password,
                SignUpDate = DateTime.Now
            };

            return await _usersRepository.CreateUser(userToSave);
        }
    }
}
