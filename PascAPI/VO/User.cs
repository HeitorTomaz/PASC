using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.VO
{
    public class User
    {
        public string UserIdpId { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }
        public string Sector { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Cpf { get; set; }
        public List<string> Emails { get; set; }
        public string EmailVerified { get; set; }

        [DataType(DataType.PhoneNumber)]
        public List<string> PhoneNumbers { get; set; }

        public Gender? Gender { get; set; }
        public string SignInProvider { get; internal set; }
    }
}
