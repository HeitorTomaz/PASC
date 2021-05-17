using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Util
{
    public static class ControllersUtil
    {
        public static VO.User ReadUser(VO.User _user, DAL.ISql _sql, ILogger _log, string _TraceIdentifier)
        {

            return _user;
//            _log.LogInformation("{_TraceIdentifier} | Begin read user | code: {Code}", _TraceIdentifier, _user.UserId);
//            var user = _sql.GetUser(_user.UserId);
//            if (user == null)
//            {
//                _sql.NewUser(_user);
//                user = _sql.GetUser(_user.UserId);
//            }
//#if DEBUG
//            _log.LogInformation("{_TraceIdentifier} | End read user | code: {Code}", _TraceIdentifier, _user.UserId);
//            user.UniversityAbbreviation = "UFRJ";
//            return user;
//#endif
//            if (user.CollegeEmail == null)
//                throw new InvalidDataException("Email was not recognized as a college email");

//            _log.LogInformation("{_TraceIdentifier} | End read user | code: {Code}", _TraceIdentifier, _user.UserId);
//            return user;
        }
    }
}
