using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.DTO
{
    public class User
    {
        public User() { }

        public string Guid { get; set; }
        public string Name { get; set; }
        public List<string> Email { get; set; }
        public string  IdentityProvider { get; set; }
        public int? Age { get; set; }
        public DateTime? Birth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
