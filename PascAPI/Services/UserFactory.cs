using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using PASC.Services.Storage;
using System.Text.Json;
using PASC.VO;

namespace PASC.Services
{
    public class UserFactory : IUserFactory
    {
        //private readonly StorageHelper _storage;
        private readonly IHttpContextAccessor _accessor;

        public UserFactory(IHttpContextAccessor context)
        {
            _accessor = context;
            //_storage = storageHelper;
        }

        public VO.User GenerateUser()
        {
            var usr = _accessor.HttpContext.User;
            //var idp = usr.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/identityprovider");
            //var Code = usr.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //var Name = usr.Claims.FirstOrDefault(x => x.Type == "name");
            //var FamilyName = usr.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname);
            //var JobTitle = usr.Claims.FirstOrDefault(x => x.Type == "jobTitle");
            //var City = usr.Claims.FirstOrDefault(x => x.Type == "city");
            //var Country = usr.Claims.FirstOrDefault(x => x.Type == "country");
            //var PostalCode = usr.Claims.FirstOrDefault(x => x.Type == "postalCode");
            var FirebaseAuth = JsonSerializer.Deserialize<Firebase>(usr.Claims.FirstOrDefault(x => x.Type == "firebase").Value) ;  

            return new VO.User()
            {
                //Code = Code.Value,
                //Name = Name?.Value,
                //FamilyName = FamilyName?.Value,
                //JobTitle = JobTitle?.Value,
                //City = City?.Value,
                //Country = Country?.Value,
                //PostalCode = PostalCode?.Value,
                Emails = FirebaseAuth.identities.email,
                IdentityProvider = FirebaseAuth.sign_in_provider
            };
        }

        public DTO.User GenerateUserDto(VO.User user)
        {
            int? age = null;
            if (user.Birth != null)
                age = Convert.ToInt32((DateTime.Today - (DateTime)user.Birth).TotalDays) / 365;

            return new DTO.User()
            {
                Name = user.Name,
                Age = age,
                PhoneNumber = user.PhoneNumber,
                Birth = user.Birth,
                Email = user.Emails,
                IdentityProvider = user.IdentityProvider
            };
        }


    }
}
