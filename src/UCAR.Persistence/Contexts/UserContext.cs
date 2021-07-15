using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCAR.Domain.Entities;
using UCAR.Domain.Interfaces.Repositories;

namespace UCAR.Persistence.Contexts
{
    public class UserContext : DbContext, IUsersRepository
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        private DbSet<User> Users { get; set; }

        public async Task<User> CreateUser(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
            return user;
        }

        public Task<List<User>> FindAll()
        {
            return Users.ToListAsync();
        }

        public Task<User> FindUserByEmail(string email)
        {
            return Users.SingleAsync((user) => user.Email == email);
        }

        public Task<User> FindUserById(int id)
        {
            return Users.SingleOrDefaultAsync((user) => user.Id == id);
        }
    }
}
