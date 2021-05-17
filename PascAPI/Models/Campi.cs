using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Campi
    {
        public int CampiId { get; set; }
        public string Description { get; set; }
        public DateTime Created  { get; set; }


        public IList<Center> Centers { get; set; }

    }
}
