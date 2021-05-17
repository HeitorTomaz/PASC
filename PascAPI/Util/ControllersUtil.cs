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

            //return _user;
            _log.LogInformation("{_TraceIdentifier} | Begin read user | code: {Code}", _TraceIdentifier, _user.UserIdpId);
            var user = _sql.GetUser(_user.UserIdpId);
            if (user == null)
            {
                _sql.NewUser(_user);
                user = _sql.GetUser(_user.UserIdpId);
            }

            _log.LogInformation("{_TraceIdentifier} | End read user | code: {Code}", _TraceIdentifier, _user.UserIdpId);
            return user;
        }
    }
}
