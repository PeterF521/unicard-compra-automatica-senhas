using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCAR.Domain.Entities;

namespace UCAR.Domain.Exceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException(User userRegistered)
            : base($"O e-mail \"{userRegistered.Email}\" já se encontra registado.")
        {
            UserRegistered = userRegistered;   
        }

        public User UserRegistered { get; private set; }
    }
}
