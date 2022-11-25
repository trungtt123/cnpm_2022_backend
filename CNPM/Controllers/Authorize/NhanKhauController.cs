using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CNPM.Service.Interfaces;
using CNPM.Core.Models;
using CNPM.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CNPM.Service.Implementations;
using CNPM.Core.Models.NhanKhau;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CNPM.Controllers.Authorize
{
    [VerifyToken]
    [Authorize]
    [ApiController]
    [Route(Constant.API_BASE)]

    public class NhanKhauController : ControllerBase
    {
        private readonly INhanKhauService _nhanKhauService;
        public NhanKhauController(INhanKhauService nhanKhauService)
        {
            _nhanKhauService = nhanKhauService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("nhan-khau/danh-sach-nhan-khau")]
        public IActionResult GetListNhanKhau(int index, int limit)
        {
            return _nhanKhauService.GetListNhanKhau(index, limit);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("nhan-khau/danh-sach-nhan-khau-trong-ho-khau")]
        public IActionResult GetListNhanKhauInHoKhau(string maHoKhau)
        {
            return _nhanKhauService.GetListNhanKhauInHoKhau(maHoKhau);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("nhan-khau")]
        public IActionResult GetNhanKhau(int maNhanKhau)
        {
            return _nhanKhauService.GetNhanKhau(maNhanKhau);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("nhan-khau")]
        public IActionResult CreateNhanKhau([FromBody] NhanKhauDto1000 nhanKhau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(nhanKhau);
            }
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            return _nhanKhauService.CreateNhanKhau(token, nhanKhau);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("nhan-khau")]
        public IActionResult UpdateNhanKhau([FromBody] NhanKhauDto1002 nhanKhau, int maNhanKhau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(nhanKhau);
            }
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            return _nhanKhauService.UpdateNhanKhau(token, maNhanKhau, nhanKhau);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("nhan-khau")]
        public IActionResult XoaNhanKhau(int maNhanKhau, int version)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            return _nhanKhauService.DeleteNhanKhau(maNhanKhau, token, version);
        }

    }
}