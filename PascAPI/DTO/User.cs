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

        public string userIdpId { get; set; }
        public string Name { get; set; }
        public List<string> Emails { get; set; }
        public string EmailVerified { get; set; }
        public string  SignInProvider { get; set; }
        public int? Age { get; set; }
        public DateTime? Birth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public List<string> PhoneNumbers { get; set; }
    }
}
