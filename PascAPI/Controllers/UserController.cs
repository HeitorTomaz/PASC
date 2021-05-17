using ByteSizeLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PASC.Services;
using PASC.Services.Storage;

namespace PASC.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VO.User _user;
        private readonly DAL.ISql _sql;
        private readonly ILogger _log;
        private readonly string _TraceIdentifier;
        private readonly IUserFactory _userFactory;

        public UserController(IUserFactory userFactory, IHttpContextAccessor accessor, DAL.ISql sql,
                                ILogger<UserController> log)
        {
            _log = log;
            _user = userFactory.GenerateUser();
            _sql = sql;
            _userFactory = userFactory;
            _TraceIdentifier = accessor.HttpContext.TraceIdentifier;
            _user = Util.ControllersUtil.ReadUser(_user, _sql, _log, _TraceIdentifier);
            
        }


        // GET user
        [HttpGet]
        public ActionResult GetUser()
        {
            _log.LogInformation("{_TraceIdentifier} | Begin get user | code: {Code}", _TraceIdentifier, _user.UserIdpId);

            var userDto = _userFactory.GenerateUserDto(_user);

            _log.LogInformation("{_TraceIdentifier} | End get user | code: {Code}", _TraceIdentifier, _user.UserIdpId);

            return Ok(userDto);

        }

        // GET user
        [HttpGet("test")]
        public ActionResult GetTest()
        {
            return Ok();
        }

        //// POST user birth
        //[HttpPost("Birth/{birth}")]
        //public ActionResult SetUserBirth(DateTime birth)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin set user birth | code: {Code}", _TraceIdentifier, _user.UserId);
        //    _sql.SetUserBirth(_user, birth);
        //    _log.LogInformation("{_TraceIdentifier} | End set user birth | code: {Code}", _TraceIdentifier, _user.UserId);

        //    return Ok();
        //}

        //// POST user gender
        //[HttpPost("Gender/{gender}")]
        //public ActionResult SetUserGender(VO.Gender gender)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin set user gender | code: {Code}", _TraceIdentifier, _user.UserId);
        //    _sql.SetUserGender(_user, gender);
        //    _log.LogInformation("{_TraceIdentifier} | End set user gender | code: {Code}", _TraceIdentifier, _user.UserId);

        //    return Ok();
        //}


    }
}
