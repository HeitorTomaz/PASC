using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public DateTime Created  { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public UserRole Role { get; set; }

    }
}
