using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCAR.Domain.Entities;

namespace UCAR.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User> CreateUser(User user);

        Task<User> FindUserByEmail(string email);

        Task<User> FindUserById(int id);

        Task<List<User>> FindAll();
    }
}
