using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PASC.Models;

namespace PASC.DAL
{
    public class Sql : ISql
    {
        private readonly PascContext _context;
        private readonly ILogger _log;
        private readonly string _TraceIdentifier;

        public Sql(PascContext context, IHttpContextAccessor accessor, ILogger<Sql> log)
        {
            _context = context;
            _log = log;
            _TraceIdentifier = accessor.HttpContext.TraceIdentifier;
        }


        //#region Private
        //private IQueryable<Models.Identity> GetModelIdentity(string code)
        //{
        //    try
        //    { 
        //        _log.LogInformation("{_TraceIdentifier} | Begin Get Model Identity | Code: {code}", _TraceIdentifier, code);
        //        return _context.Identity
        //                .Include(Identity => Identity.User)
        //                    .ThenInclude(User => User.Domain)
        //                .Include(Identity => Identity.User.Gender)
        //                .Include(Identity => Identity.Emails)
        //                .Where(Identity => Identity.Code == code);
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Get Model Identity | Code: {code}", _TraceIdentifier, code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Get Model Identity | Code: {code}", _TraceIdentifier, code);

        //    }
        //}

        //private IQueryable<Models.Identity> GetModelIdentities(List<int> ids)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Get Model Identities ", _TraceIdentifier);
        //        return _context.Identity
        //                    .Include(x => x.User)
        //                        .ThenInclude(usr => usr.Domain)
        //                            .ThenInclude(Domain => Domain.University)
        //                    .Include(x => x.User.Photos)
        //                    .Where(x => ids.Contains(x.IdentityId));
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Get Model Identities ", _TraceIdentifier);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Get Model Identities ", _TraceIdentifier);

        //    }
        //}

        //private Models.Gender GetModelGender(VO.Gender gender)
        //{
        //    var strGender = gender.ToString();
        //    _log.LogError("{_TraceIdentifier} | Begin Get Model Gender | Gender: {strGender}", _TraceIdentifier, strGender);

        //    try
        //    { 
        //        return _context.Gender.FirstOrDefault(x => x.Name == strGender);
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Get Model Gender | Gender: {strGender}", _TraceIdentifier, strGender);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Get Model Gender | Gender: {strGender}", _TraceIdentifier, strGender);

        //    }
        //}

        //#endregion


        //public VO.User GetUser(string code)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin Get User | Code: {code}", _TraceIdentifier, code);
        //    try
        //    {
        //        return GetModelIdentity(code)
        //                .Include(x=>x.User.Photos)
        //                .FirstOrDefault()?.MapToVO();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Get User | Code: {code}", _TraceIdentifier, code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Get User | Code: {code}", _TraceIdentifier, code);

        //    }
        //}

        //public void NewUser(VO.User user)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code}", _TraceIdentifier, user.Code);
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add educational domain", _TraceIdentifier, user.Code);

        //        //Add educational email domain
        //        var domains = _context.Domain.ToList();
        //        Domain dom = null;
        //        string CollegeEmail = null;
        //        foreach (var email in user.Emails)
        //        {
        //            if (domains.Any(x => email.EndsWith(x.Name)))
        //            {
        //                dom = domains.FirstOrDefault(x => email.EndsWith(x.Name));
        //                CollegeEmail = email;
        //                break;
        //            }
        //        }

        //        _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add user", _TraceIdentifier, user.Code);

        //        //Add user
        //        var gnd = _context.Gender.FirstOrDefault(x => x.Name == user.Gender.ToString());
        //        var usr = new User()
        //        {
        //            Domain = dom,
        //            Gender = gnd,
        //            CollegeEmail = CollegeEmail
        //        };

        //        _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add identity", _TraceIdentifier, user.Code);

        //        //Add identity
        //        var idp = _context.IdentityProvider.FirstOrDefault(x => x.Code == user.IdentityProvider);

        //        var idn = new Identity()
        //        {
        //            IdentityProvider = idp,
        //            User = usr,
        //            Code = user.Code,
        //            Name = user.Name,
        //            FamilyName = user.FamilyName,
        //            JobTitle = user.JobTitle,
        //            City = user.City,
        //            Country = user.Country,
        //            PostalCode = user.PostalCode
        //        };

        //        _context.Add(idn);

        //        _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add all emails", _TraceIdentifier, user.Code);

        //        //Add all emails
        //        user.Emails.ForEach(x => _context.Add(new Email() { Address = x, Identity = idn }));

        //        _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Save changes", _TraceIdentifier, user.Code);

        //        _context.SaveChanges();

        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | End New User | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | New User | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserBirth(VO.User user, DateTime birth)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Set User Birth | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        id.User.Birth = birth;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Set User Birth | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Set User Birth | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserGender(VO.User user, VO.Gender gender)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Add User Gender | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        id.User.Gender = GetModelGender(gender);
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Add User Gender | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Add User Gender | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserInstagram(VO.User user, string instagram)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Set User Instagram | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        id.User.Instagram = instagram;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Set User Instagram | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Set User Instagram | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserPhone(VO.User user, string phone)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Set User phone | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        id.User.PhoneNumber = phone;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Set User phone | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Set User phone | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserFacebook(VO.User user, string facebook)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Set User facebook | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        id.User.Facebook = facebook;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Set User facebook | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Set User facebook | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public void SetUserPhoto(VO.User user, VO.Image image, int number = 1)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        if (GetUserPhotoNumbers(user).Contains(number))
        //        {
        //            var img = _context.Photo.FirstOrDefault(x => x.User == id.User);
        //            img.Name = image.Name;
        //        }
        //        else
        //        {
        //            var img = new Models.Photo(image)
        //            {
        //                User = id.User,
        //                Number = number
        //            };                    
        //            _context.Add(img);
        //        }
        //            _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}

        //public List<int> GetUserPhotoNumbers (VO.User user)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code).FirstOrDefault();
        //        return _context.Photo.Where(x => x.User == id.User).Select(x => x.Number).ToList();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Add User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}
        
        //public VO.Image GetUserPhoto(VO.User user, int number = 1)
        //{
        //    try
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | Begin Get User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        var id = GetModelIdentity(user.Code)
        //                .FirstOrDefault();

        //        var photo = _context.Photo
        //                .FirstOrDefault(x => x.User == id.User && x.Number == number);

        //        return photo?.MapToVO();
        //    }
        //    catch
        //    {
        //        _log.LogError("{_TraceIdentifier} | Get User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //        throw;
        //    }
        //    finally
        //    {
        //        _log.LogInformation("{_TraceIdentifier} | End Get User Photo | Code: {Code}", _TraceIdentifier, user.Code);
        //    }
        //}
        

    }
}
