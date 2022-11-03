using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CNPM.Service.Interfaces;
using CNPM.Core.Models;
using CNPM.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WareHouse.Controllers
{
    [VerifyRoleFilter]
    [Authorize]
    [ApiController]
    [Route(Constant.API_BASE)]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserDto1004 userData)
        {
            var user = _userService.Authenticate(userData);

            var response = new ResponseDto();

            if (user == null)
            {
                response.Message = Constant.USERNAME_OR_PASSWORD_IS_INCORRECT;

                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.AUTHENTICATION_SUCCESSFULLY;
            response.Data = user;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPost("logout")]
        public IActionResult Logout(string userName)
        {
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var kt = _userService.Logout(userName, accessToken);

            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.LOGOUT_FAILED;

                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.LOGOUT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("verify-token")]
        public IActionResult VerifyToken()
        {
            var response = new ResponseDto();
            response.Message = Constant.INVALID_TOKEN;
            try
            {
                var jwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var kt = _userService.VerifyToken(jwt);
                var userName = Helpers.DecodeJwt(jwt, "username");
                var userData = _userService.GetUser(userName);
                if (!kt) return new UnauthorizedResult();
                response.Message = Constant.VALID_TOKEN;
                response.Data = userData;
                return Ok(Helpers.SerializeObject(response));
            }
            catch (Exception ex)
            {
                return new UnauthorizedResult();
            }
        }

        [HttpGet("get-list-permissions")]
        [AllowAnonymous]
        public IActionResult GetListPermissions()
        {
            var response = new ResponseDto();
            var listPermissions = _userService.GetListPermissions();
            if (listPermissions != null)
            {
                response.Message = Constant.GET_LIST_PERMISSIONS_SUCCESSFULLY;
                response.Data = listPermissions;
                return Ok(Helpers.SerializeObject(response));
            }
            else
            {
                response.Message = Constant.GET_LIST_PERMISSIONS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("user")]
        public IActionResult GetUser(string userName)
        {
            var user = _userService.GetUser(userName);
            var response = new ResponseDto();
            if (user == null)
            {

                response.Message = Constant.GET_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_USER_SUCCESSFULLY;
            response.Data = user;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("user")]
        public IActionResult CreateUser([FromBody] UserDto1005 user)
        {
            var userResponse = _userService.CreateUser(user);
            var response = new ResponseDto();

            if (userResponse == null)
            {
                response.Message = Constant.CREATE_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CREATE_USER_SUCCESSFULLY;
            response.Data = userResponse;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("user")]
        public IActionResult UpdateUser([FromBody] UserDto1006 newUserData)
        {
            var kt = _userService.UpdateUser(newUserData);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_USER_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("user")]
        public IActionResult DeleteUser(string userName)
        {
            var kt = _userService.DeleteUser(userName);
            var response = new ResponseDto();

            if (kt)
            {

                response.Message = Constant.DELETE_USER_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_USER_FAILED;
            return BadRequest(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var response = new ResponseDto();

            if (users == null)
            {
                response.Message = Constant.GET_LIST_USERS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_USERS_SUCCESSFULLY;
            response.Data = users;
            return Ok(Helpers.SerializeObject(response));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPut("change-password")]

        public IActionResult ChangePassWord([FromBody] UserDto1000 userData)
        {
            var kt = false;
            var jwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var userName = Helpers.DecodeJwt(jwt, "username");

            if (userName == userData.UserName) kt = _userService.ChangePassWord(userData);
            var response = new ResponseDto();
            if (!kt)
            {
                response.Message = Constant.CHANGE_PASSWORD_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CHANGE_PASSWORD_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }
    }
}