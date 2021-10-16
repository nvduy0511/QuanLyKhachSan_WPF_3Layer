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
        private int? soGio;
        private string donDep;
        private string loaiPhong;
        private DateTime? ngayDen;
        private DateTime? ngayDi;
        private bool? isDay;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DonDep { get => donDep; set => donDep = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public DateTime? NgayDen { get => ngayDen; set => ngayDen = value; }
        public int? SoNguoi { get => soNguoi; set => soNguoi = value; }
        public int? SoNgayO { get => soNgayO; set => soNgayO = value; }
        public int? MaCTPT { get => maCTPT; set => maCTPT = value; }
        public DateTime? NgayDi { get => ngayDi; set => ngayDi = value; }
        public int? SoGio { get => soGio; set => soGio = value; }
        public bool? IsDay {
            get 
            {
                return this.SoGio >= 24;
            }
            set => isDay = value; 
        }
    }
}
