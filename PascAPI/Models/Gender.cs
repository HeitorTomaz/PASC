using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }


        public IList<User> users { get; set; }
    }
}
