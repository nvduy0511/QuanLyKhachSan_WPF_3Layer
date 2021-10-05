using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class Phong_Custom
    {
        private int? maCTPT;
        private string maPhong;
        private string tinhTrang;
        private string tenKH;
        private int? soNgayO;
        private int? soNguoi;
        private string donDep;
        private string loaiPhong;
        private DateTime? ngayDen;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DonDep { get => donDep; set => donDep = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public DateTime? NgayDen { get => ngayDen; set => ngayDen = value; }
        public int? SoNguoi { get => soNguoi; set => soNguoi = value; }
        public int? SoNgayO { get => soNgayO; set => soNgayO = value; }
        public int? MaCTPT { get => maCTPT; set => maCTPT = value; }
    }
}
