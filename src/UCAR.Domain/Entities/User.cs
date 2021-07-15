using System;
using UCAR.Domain.Common;

namespace UCAR.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string EducatorEmail { get; set; }

        public string Password { get; set; }

        public DateTime SignUpDate { get; set; }
    }
}
