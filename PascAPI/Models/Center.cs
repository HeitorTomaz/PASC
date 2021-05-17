using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Center
    {
        public int CenterId { get; set; }
        public string Description { get; set; }

        public int  CampiId { get; set; }
        public Campi  Campi { get; set; }

        public IList<Building> Buildings { get; set; }

    }
}
