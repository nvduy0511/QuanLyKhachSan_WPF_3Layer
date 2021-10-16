using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PhieuThue_Custom
    {
        private int maPhieuThue;
        private string tenKH;
        private string tenNV;
        private DateTime? ngayLapPhieu;

        public int MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public DateTime? NgayLapPhieu { get => ngayLapPhieu; set => ngayLapPhieu = value; }
    }
}
