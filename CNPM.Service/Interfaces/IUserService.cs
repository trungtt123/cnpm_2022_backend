using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.Core.Models;


namespace CNPM.Service.Interfaces
{
    public interface IUserService
    {
        public bool VerifyToken(string token);
        public UserDto1002 Authenticate(UserDto1004 userLogin);

        public bool Logout(string userName, string accessToken);
        public UserDto1003 CreateUser(UserDto1005 user);
        public bool UpdateUser(UserDto1006 newUserData);
        public bool DeleteUser(string userName);

        public UserDto1003 GetUser(string userName);
        public bool ChangePassWord(UserDto1000 userData);
        public List<RoleDto> GetListPermissions();
        public List<UserDto1001> GetAllUsers();
    }
}
