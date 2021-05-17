using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Acceptance
    {
        public int AcceptanceId { get; set; }
        public string Path { get; set; }


        public IList<UserAcceptance> UserAcceptances { get; set; }
    }
}
