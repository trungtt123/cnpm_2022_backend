using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.Core.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TrangThaiAttribute : ValidationAttribute
    {
        public static ValidationResult IsTrangThai(int trangThai)
        {
            if (trangThai == 0 || trangThai == 1) // trang thai = 0 da chet, 1 da chet
                return ValidationResult.Success;
            else
                return new ValidationResult("Trang thai is not valid, trang thai = 0 as die, = 1 as alive");
        }
    }
}
