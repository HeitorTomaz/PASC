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
        public DateTime? Birth { get; set; }
        public string PhotoPath { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public double Height { get; set; }

        public string UserIdpId { get; set; }
        public string SignInProvider { get; set; }

        public int? GenderId{ get; set; }
        public Gender? Gender { get; set; }

        public IList<UserAcceptance> UserAcceptances { get; set; }
        public IList<Answer> Answers { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Pass> Passes { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<UserBuilding> UserBuildings { get; set; }

        public IList<UserSector> UserSector { get; set; }

        public IList<Email> Emails { get; set; }



        public VO.User MapToVO()
        {
            var today = DateTime.Today;
            int age = (int)(this.Birth == null ? 0 : today.Year - this.Birth?.Year);
            var gndrStr = this.Gender?.Name;
            var gndr = gndrStr == null ? new VO.Gender() : Enum.Parse<VO.Gender>(gndrStr);

            return new VO.User() 
                { 
                UserIdpId = this.UserIdpId,
                Name = this.Name,
                Birth = this.Birth,
                Age = (this.Birth?.Date > today.AddYears(-age) ? age-- : age) ,
                Surname = this.Surname,
                Sector = this.UserSector?.OrderBy(x=>x.Created)?.FirstOrDefault()?.Sector?.Description,
                City = this.City,
                District = this.District,
                Emails = this.Emails.Select(x=>x.Address).ToList(),
                PhoneNumbers = this.Phones.Select(x=>x.Number).ToList(),
                Gender = gndr,
                SignInProvider = this.SignInProvider
            };
        
        }

    }
}
