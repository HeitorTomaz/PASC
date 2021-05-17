using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
        public DateTime Created  { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

    }
}
