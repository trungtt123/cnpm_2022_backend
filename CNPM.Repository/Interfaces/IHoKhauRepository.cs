using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.Core.Entities;
using CNPM.Core.Models;

namespace CNPM.Repository.Interfaces
{
    public interface IHoKhauRepository
    {
        public List<HoKhauEntity> GetListHoKhau();
    }
}
