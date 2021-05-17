using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Unity
    {
        public int UnityId { get; set; }
        public string Description { get; set; }

        public IList<Sector> Sector { get; set; }

    }
}
