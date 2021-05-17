using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Description { get; set; }

        public int  CenterId { get; set; }
        public Center  Center { get; set; }

        public IList<UserBuilding> UserBuildings { get; set; }

    }
}
