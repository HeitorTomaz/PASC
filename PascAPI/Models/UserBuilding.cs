using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class UserBuilding
    {
        public int UserBuildingId { get; set; }
        public DateTime Created { get; set; }

        public int  BuildingId { get; set; }
        public Building  Building { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
