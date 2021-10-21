using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DichVuDTO
    {
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string LoaiDichVu { get; set; }
        public decimal Gia { get; set; }
    }
}
