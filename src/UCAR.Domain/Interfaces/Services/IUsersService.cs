using System.Threading.Tasks;
using UCAR.Domain.Entities;
using UCAR.Domain.InputDTOs;

namespace UCAR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<User> CreateUser(CreateUserInputDTO user);

        Task<bool> CheckCredentials(CheckUserCredentialsInputDTO credentials);
    }
}
