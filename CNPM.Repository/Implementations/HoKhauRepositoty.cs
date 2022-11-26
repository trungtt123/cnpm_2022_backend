using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.Repository.Interfaces;
using CNPM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using CNPM.Core.Utils;
using CNPM.Core.Models;
using CNPM.Core.Models.NhanKhau;

namespace CNPM.Repository.Implementations
{
    public class HoKhauRepository : IHoKhauRepository
    {
        private readonly MyDbContext _dbcontext;
      
        public HoKhauRepository()
        {
            _dbcontext = new MyDbContext();
        }

        public List<HoKhauEntity> GetListHoKhau(int index, int limit)
        {
            try
            {
                List<HoKhauEntity> arr;
                if (index == 0 && limit == 0)
                {
                    arr = _dbcontext.HoKhau.Where(
                    o => o.Delete == Constant.NOT_DELETE).ToList();
                }
                else arr = _dbcontext.HoKhau.Where(
                    o => o.Delete == Constant.NOT_DELETE).Skip(limit * (index - 1)).Take(limit).ToList();

                return arr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public HoKhauEntity GetHoKhau(string maHoKhau)
        {
            try
            {
                HoKhauEntity hoKhau = _dbcontext.HoKhau.Where(
                    o => o.Delete == Constant.NOT_DELETE && o.MaHoKhau == maHoKhau).FirstOrDefault();
                return hoKhau;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string CreateHoKhau(HoKhauEntity hoKhau)
        {
            try
            {
                if (hoKhau.MaHoKhau == null || hoKhau.MaHoKhau == "")
                {
                    hoKhau.MaHoKhau = GetRandomMaHoKhau();
                }
                _dbcontext.HoKhau.Add(hoKhau);

                int number_rows = _dbcontext.SaveChanges();

                if (number_rows <= 0) return "";

                return hoKhau.MaHoKhau;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AddNhanKhauToHoKhau(List<int> danhSachNhanKhau, string maHoKhau, string userName)
        {
            try
            {
                // them nhan khau moi vao ho khau
                for (var i = 0; i < danhSachNhanKhau.Count; i++)
                {
                    var nhanKhau = _dbcontext.NhanKhau.Where(
                    o => o.Delete == Constant.NOT_DELETE && o.MaNhanKhau == danhSachNhanKhau[i]).FirstOrDefault();
                    if (nhanKhau != null && nhanKhau.MaHoKhau == null)
                    {
                        nhanKhau.MaHoKhau = maHoKhau;
                        nhanKhau.UserUpdate = userName;
                        nhanKhau.UpdateTime = DateTime.Now;
                        nhanKhau.Version++;
                    }
                    
                }
                _dbcontext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveNhanKhauFromHoKhau(string maHoKhau, string userName)
        {
            try
            {
                //xoa nhan khau cu trong ho khau
                var listNhanKhau = _dbcontext.NhanKhau.Where(
                    o => o.Delete == Constant.NOT_DELETE && o.MaHoKhau == maHoKhau).ToList();
                for (var i = 0; i < listNhanKhau.Count; i++)
                {
                    listNhanKhau[i].MaHoKhau = null;
                    listNhanKhau[i].UserUpdate = userName;
                    listNhanKhau[i].UpdateTime = DateTime.Now;
                    listNhanKhau[i].Version++;
                }
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckMaHoKhauExisted(string maHoKhau)
        {
            try
            {
                HoKhauEntity hoKhau = _dbcontext.HoKhau.Where(
                    o => o.MaHoKhau == maHoKhau).FirstOrDefault();
                if (hoKhau == null) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GetRandomMaHoKhau()
        {
            try
            {
                string maHoKhau;
                while (true)
                {
                    Random rnd = new Random();
                    maHoKhau = "HK" + rnd.Next(100000000).ToString().PadLeft(8, '0');
                    var arr = _dbcontext.HoKhau.Where(o => o.Delete == Constant.NOT_DELETE).ToList();
                    bool kt = true;
                    for (var i = 0; i < arr.Count; i++)
                    {
                        if (arr[i].MaHoKhau == maHoKhau)
                        {
                            kt = false;
                            break;
                        }
                    }
                    if (kt) break;
                }
                return maHoKhau;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateHoKhau(HoKhauEntity newHoKhau)
        {
            try
            {
                var hoKhau = _dbcontext.HoKhau.FirstOrDefault(
                    o => o.MaHoKhau == newHoKhau.MaHoKhau && o.Delete == Constant.NOT_DELETE);

                if (hoKhau != null)
                {
                    hoKhau.UserUpdate = newHoKhau.UserUpdate;
                    hoKhau.UpdateTime = newHoKhau.UpdateTime;
                    hoKhau.DiaChiThuongTru = newHoKhau.DiaChiThuongTru;
                    hoKhau.NoiCap = newHoKhau.NoiCap;
                    hoKhau.NgayCap = newHoKhau.NgayCap;
                    hoKhau.Version = newHoKhau.Version;
                    _dbcontext.SaveChanges();
                    return newHoKhau.MaHoKhau;
                }
                else return "";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteHoKhau(string maHoKhau, string userNameUpdate)
        {
            try
            {
                var hoKhau = _dbcontext.HoKhau.FirstOrDefault(
                    o => o.MaHoKhau == maHoKhau && o.Delete == Constant.NOT_DELETE);
                if (hoKhau != null)
                {
                    hoKhau.Delete = Constant.DELETE;
                    hoKhau.UserUpdate = userNameUpdate;
                    hoKhau.UpdateTime = DateTime.Now;
                    hoKhau.Version++;
                    _dbcontext.SaveChanges();
                    return true;
                }
               
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
