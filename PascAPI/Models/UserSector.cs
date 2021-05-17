using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class UserSector
    {
        public int UserSectorId { get; set; }
        public DateTime Created { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
