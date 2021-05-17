using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Pass
    {
        public int PassId { get; set; }
        public bool Allowed { get; set; }
        public DateTime Created  { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

    }
}
