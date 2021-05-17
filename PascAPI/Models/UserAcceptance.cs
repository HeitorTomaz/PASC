using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class UserAcceptance
    {
        public int UserAcceptanceId { get; set; }
        public DateTime Created { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int AcceptanceId { get; set; }
        public Acceptance Acceptance { get; set; }
    }
}
