using CNPM.Core.Models;
using CNPM.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CNPM.Core.Entities;
using CNPM.Core.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using CNPM.Service.Interfaces;
using System.Net.Mail;

namespace CNPM.Service.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _iconfiguration;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IConfiguration iconfiguration)
        {
            _userRepository = userRepository;
            _iconfiguration = iconfiguration;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public bool VerifyToken(string token)
        {
            try
            {
                var userName = Helpers.DecodeJwt(token, "username");
                var roleId = Int32.Parse(Helpers.DecodeJwt(token, "role"));
                var userVersion = Int32.Parse(Helpers.DecodeJwt(token, "version"));
                var user = _userRepository.GetUser(userName);
                var checkToken = _userRepository.CheckToken(userName, token);
                if (user == null || user.RoleId != roleId || user.Version != userVersion || !checkToken) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<UserDto1001> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            List<UserDto1001> arr = _mapper.Map<List<UserEntity>, List<UserDto1001>>(users);
            return arr;
        }
        public UserDto1002 Authenticate(UserDto1004 userLogin)
        {

            var user = _userRepository.GetUser(userLogin.UserName);

            if (user == null) return null;

            bool isValidPassWord = Helpers.IsValidPassWord(userLogin.Password, user.Password);

            if (!isValidPassWord) return null;

            var claims = new[]
        {
            

            new Claim("username", user.UserName),

            new Claim("firstname", user.FirstName),

            new Claim("lastname", user.LastName),

            new Claim("version", user.Version.ToString()),

            new Claim("role", user.RoleId.ToString()),

        };
            var token = new JwtSecurityToken
            (
                issuer: _iconfiguration["Jwt:Issuer"],
                audience: _iconfiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            UserDto1002 userDto = _mapper.Map<UserEntity, UserDto1002>(user);

            userDto.Token = tokenString;

            userDto.RoleId = user.RoleId;

            _userRepository.SaveToken(userLogin.UserName, tokenString);

            return userDto;
        }
        public bool Logout(string userName, string accessToken)
        {
            return _userRepository.DeleteToken(userName, accessToken);
        }

        public UserDto1003 GetUser(string userName)
        {
            UserEntity user = _userRepository.GetUser(userName);

            if (user == null) return null;

            var userInfomation = _mapper.Map<UserEntity, UserDto1003>(user);

            return userInfomation;
        }
        public UserDto1003 CreateUser(UserDto1005 user)
        {
            var userTmp = _userRepository.GetUser(user.UserName);
            if (userTmp != null) return null;

            UserEntity userEntity;
            UserDto1003 userInfomation;

            userEntity = _mapper.Map<UserDto1005, UserEntity>(user);
            userInfomation = _mapper.Map<UserDto1005, UserDto1003>(user);

            string password = Helpers.RandomString(Constant.RANDOM_DEFAULT_PASSWORD_LENGTH);

            userEntity.Password = Helpers.GetHashPassword(password);
          
            var userResponse = _userRepository.CreateUser(userEntity);
            
            
            if (userResponse != null)
            {
                return userInfomation;

            }
            return null;
        }

        public bool UpdateUser(UserDto1006 newUserData)
        {
            UserEntity userEntity;

            userEntity = _mapper.Map<UserDto1006, UserEntity>(newUserData);
         
            return _userRepository.UpdateUser(userEntity);
        }

        public bool DeleteUser(string userName)
        {
      
            return _userRepository.DeleteUser(userName);

        }
        public List<RoleDto> GetListPermissions()
        {
           
            List<RoleEntity> arrPermissionEntity = _userRepository.GetListPermissions();
            List<RoleDto> arrPermissionDto = _mapper.Map<List<RoleEntity>, List<RoleDto>>(arrPermissionEntity);
            return arrPermissionDto;
        }
        public bool ChangePassWord(UserDto1000 userData)
        {
            
            var user = _userRepository.GetUser(userData.UserName);

            if (user == null) return false;

            bool isValidPassWord = Helpers.IsValidPassWord(userData.OldPassword, user.Password);

            if (!isValidPassWord) return false;

            bool kt = _userRepository.ChangePassWord(user.UserName, Helpers.GetHashPassword(userData.NewPassword));

            return kt;
        }
    

    }
}