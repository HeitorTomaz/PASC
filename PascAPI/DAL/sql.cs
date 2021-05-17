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


        #region Private
        private IQueryable<Models.User> GetModelUser(string code)
        {
            try
            {
                _log.LogInformation("{_TraceIdentifier} | Begin Get Model Identity | Code: {code}", _TraceIdentifier, code);
                return _context.User
                        .Include(user => user.UserAcceptances)
                        .Include(user => user.Phones)
                        .Include(user => user.UserRoles)
                            .ThenInclude(UserRole => UserRole.Role)
                        .Include(user => user.Gender)
                        .Include(user => user.UserSector)
                            .ThenInclude(userSector => userSector.Sector)
                            .ThenInclude(sector => sector.Unity)
                        .Include(user => user.Emails)
                        
                        .Where(User => User.UserIdpId == code);
            }
            catch
            {
                _log.LogError("{_TraceIdentifier} | Get Model Identity | Code: {code}", _TraceIdentifier, code);
                throw;
            }
            finally
            {
                _log.LogInformation("{_TraceIdentifier} | End Get Model Identity | Code: {code}", _TraceIdentifier, code);

            }
        }

        #endregion


        public VO.User GetUser(string code)
        {
            _log.LogInformation("{_TraceIdentifier} | Begin Get User | Code: {code}", _TraceIdentifier, code);
            try
            {
                return GetModelUser(code)
                        .FirstOrDefault()?.MapToVO();
            }
            catch
            {
                _log.LogError("{_TraceIdentifier} | Get User | Code: {code}", _TraceIdentifier, code);
                throw;
            }
            finally
            {
                _log.LogInformation("{_TraceIdentifier} | End Get User | Code: {code}", _TraceIdentifier, code);

            }
        }

        public void NewUser(VO.User user)
        {
            _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code}", _TraceIdentifier, user.UserIdpId);
            try
            {
               
                _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add user", _TraceIdentifier, user.UserIdpId);


                var _usr = new Models.User()
                {
                    UserIdpId = user.UserIdpId,
                    SignInProvider = user.SignInProvider,
                };

                //add to DB
                _context.Add(_usr);

                _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Add all emails", _TraceIdentifier, user.UserIdpId);

                //Add all emails to DB
                user.Emails.ForEach(x => _context.Add(new Email() { Address = x, User = _usr }));

                _log.LogInformation("{_TraceIdentifier} | Begin New User | Code: {Code} | Save changes", _TraceIdentifier, user.UserIdpId);

                //Save DB changes
                _context.SaveChanges();

            }
            catch
            {
                _log.LogError("{_TraceIdentifier} | End New User | Code: {Code}", _TraceIdentifier, user.UserIdpId);
                throw;
            }
            finally
            {
                _log.LogInformation("{_TraceIdentifier} | New User | Code: {Code}", _TraceIdentifier, user.UserIdpId);
            }
        }

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



    }
}
