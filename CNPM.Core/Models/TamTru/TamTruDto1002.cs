﻿using CNPM.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.Core.Models.TamTru
{
    public class TamTruDto1002 // body update
    {
        [Required]
        [MaxLength(100)]
        [JsonProperty("hoTen")]
        public string HoTen { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("diaChiThuongTru")]
        public string DiaChiThuongTru { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("diaChiTamTru")]
        public string DiaChiTamTru { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonProperty("canCuocCongDan")]
        public string CanCuocCongDan { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}

