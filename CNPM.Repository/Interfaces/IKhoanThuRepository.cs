using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.Core.Entities;
using CNPM.Core.Models;
using CNPM.Core.Models.NhanKhau;

namespace CNPM.Repository.Interfaces
{
    public interface IKhoanThuRepository
    {
        public List<KhoanThuEntity> GetListKhoanThu(int index, int limit);
        public KhoanThuEntity GetKhoanThu(int maKhoanThu);
        public int CreateNhanKhau(NhanKhauEntity nhanKhau);
        public bool CheckExistCanCuocCongDan(string CanCuocCongDan);
        public int UpdateNhanKhau(NhanKhauEntity nhanKhau);
        public bool DeleteNhanKhau(int maNhanKhau, string userName);

    }
}
