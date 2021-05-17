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
            var usrId = usr.Claims.FirstOrDefault(x => x.Type == "user_id").Value ;
            var emailVerified = usr.Claims.FirstOrDefault(x => x.Type == "email_verified").Value;
            var FirebaseAuth = JsonSerializer.Deserialize<Firebase>(usr.Claims.FirstOrDefault(x => x.Type == "firebase").Value) ;
            
            return new VO.User()
            {
                SignInProvider = FirebaseAuth.sign_in_provider,
                UserIdpId = usrId,
                Emails = FirebaseAuth.identities.email,
                EmailVerified = emailVerified
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
                PhoneNumbers = user.PhoneNumbers,
                Birth = user.Birth,
                Emails = user.Emails,
                SignInProvider = user.SignInProvider,
                userIdpId = user.UserIdpId,
                EmailVerified = user.EmailVerified
            };
        }


    }
}
