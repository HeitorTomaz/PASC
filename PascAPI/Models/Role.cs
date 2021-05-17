using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
        public DateTime Created  { get; set; }


        public IList<UserRole> UserRoles { get; set; }

    }
}
