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
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public string FamilyName { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
        public List<string> Emails { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }
        public string IdentityProvider { get; internal set; }
    }
}
