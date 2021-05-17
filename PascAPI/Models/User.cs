using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CPF { get; set; }
        public DateTime Birth { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
        public string PhotoPath { get; set; }
        public string State { get; set; }
        public string city { get; set; }
        public string District { get; set; }
        public double Height { get; set; }


        public int? GenderId{ get; set; }
        public Gender Gender { get; set; }

        public IList<UserAcceptance> UserAcceptances { get; set; }
        public IList<Answer> Answers { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Pass> Passes { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<UserBuilding> UserBuildings { get; set; }
        public IList<Sector> Sectors { get; set; }
        public IList<Email> Emails { get; set; }


    }
}
