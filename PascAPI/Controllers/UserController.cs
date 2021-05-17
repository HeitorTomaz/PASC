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
        //private readonly StorageHelper _storage;

        private readonly int maxPhotos = 6;

        public UserController(IUserFactory userFactory, IHttpContextAccessor accessor, DAL.ISql sql,
                                ILogger<UserController> log)
        {
            _log = log;
            //Apaguei só pra exibir
            _user = userFactory.GenerateUser();
            _sql = sql;
            _userFactory = userFactory;
            _TraceIdentifier = accessor.HttpContext.TraceIdentifier;
            //Apaguei só pra exibir
            //_user = Util.ControllersUtil.ReadUser(_user, _sql, _log, _TraceIdentifier);
            
            //_storage = storageHelper;
        }


        // GET user
        [HttpGet]
        public ActionResult GetUser()
        {
            _log.LogInformation("{_TraceIdentifier} | Begin get user | code: {Code}", _TraceIdentifier, _user.UserId);

            var userDto = _userFactory.GenerateUserDto(_user);

            _log.LogInformation("{_TraceIdentifier} | End get user | code: {Code}", _TraceIdentifier, _user.UserId);

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


        //// POST user instagram
        //[HttpPost("Instagram/{instagram}")]
        //public ActionResult SetUserInstagram(string instagram)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin set user instagram | code: {Code}", _TraceIdentifier, _user.UserId);
        //    _sql.SetUserInstagram(_user, instagram);
        //    _log.LogInformation("{_TraceIdentifier} | End set user instagram | code: {Code}", _TraceIdentifier, _user.UserId);

        //    return Ok();
        //}

        //// POST user phone
        //[HttpPost("Phone/{phone}")]
        //[DataType(DataType.PhoneNumber)]
        //public ActionResult SetUserphone(string phone)
        //{
        //    if (!ModelState.IsValid)
        //        return StatusCode((int)HttpStatusCode.BadRequest);

        //    _log.LogInformation("{_TraceIdentifier} | Begin set user phone | code: {Code}", _TraceIdentifier, _user.UserId);
        //    _sql.SetUserPhone(_user, phone);
        //    _log.LogInformation("{_TraceIdentifier} | End set user phone | code: {Code}", _TraceIdentifier, _user.UserId);

        //    return Ok();
        //}

        //// POST user facebook
        //[HttpPost("Facebook/{facebook}")]
        //public ActionResult SetUserFacebook(string facebook)
        //{
        //    _log.LogInformation("{_TraceIdentifier} | Begin set user facebook | code: {Code}", _TraceIdentifier, _user.UserId);
        //    _sql.SetUserFacebook(_user, facebook);
        //    _log.LogInformation("{_TraceIdentifier} | End set user facebook | code: {Code}", _TraceIdentifier, _user.UserId);

        //    return Ok();
        //}

//        // POST user photo
//        [HttpPost("Photo/{number}")]
//        public async Task<ActionResult> PostPhotoAsync(IFormFile image, int number = 1)
//        {
//            _log.LogInformation("{_TraceIdentifier} | Begin add user photo | code: {Code}", _TraceIdentifier, _user.UserId);

//            try
//            {
//                VO.Image img = new VO.Image();
//                //verify content type is valid
//                var type = Util.FilesUtil.GetImagesContentType(image?.FileName);
//#pragma warning disable S2589 // Boolean expressions should not be gratuitous
//                if (image == null || image.Length <= 0 || type == null || image.Length > ByteSize.FromMegaBytes(5).Bytes)
//#pragma warning restore S2589 // Boolean expressions should not be gratuitous
//                {
//                    return StatusCode((int)HttpStatusCode.UnsupportedMediaType);
//                }
//                else
//                {
//                    var userPhotoNumbers = _sql.GetUserPhotoNumbers(_user);
//                    if ((userPhotoNumbers.Count > 0 && number > userPhotoNumbers.Max() + 1) || number < 1 || number > maxPhotos)
//                        return StatusCode((int)HttpStatusCode.BadRequest);

//                    var actualPhoto =_sql.GetUserPhoto(_user, number);
//                    using (Stream inputStream = image.OpenReadStream())
//                    {
//                        img.Name = (actualPhoto == null ? Guid.NewGuid().ToString() : Path.GetFileNameWithoutExtension(actualPhoto.Name)) 
//                                    + Path.GetExtension(image.FileName).ToLowerInvariant();

//                        await _storage.UploadFileToStorage(inputStream, img.Name);
//                    }
                    
//                    _sql.SetUserPhoto(_user, img, number);
//                    return Ok();
//                }
//            }
//            catch
//            {
//                _log.LogError("{_TraceIdentifier} | Add user photo | code: {Code}", _TraceIdentifier, _user.UserId);
//                throw;
//            }
//            finally
//            {
//                _log.LogInformation("{_TraceIdentifier} | End add user photo | code: {Code}", _TraceIdentifier, _user.UserId);

//            }
//        }

    }
}
