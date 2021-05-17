using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Description { get; set; }

        public IList<UserSector> UserSector { get; set; }

        public int UnityId { get; set; }
        public Unity Unity { get; set; }
    }
}
