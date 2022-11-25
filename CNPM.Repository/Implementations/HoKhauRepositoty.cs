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
        
        public List<HoKhauEntity> GetListHoKhau()
        {
            try
            {
                List<HoKhauEntity> arr = _dbcontext.HoKhau.Where(o => o.Delete == Constant.NOT_DELETE).ToList();
                return arr;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
