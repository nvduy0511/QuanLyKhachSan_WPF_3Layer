using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNHanVienLap { get; set; }
        public decimal TongTien { get; set; }
        public int MaCTPhieuThue { get; set; }
    }
}
