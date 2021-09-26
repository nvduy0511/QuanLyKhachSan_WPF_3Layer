using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Class
{
    public class NhanVien
    {
        private string maNV;
        private string hoTenNV;
        private DateTime nTNS;
        private string chucVu;
        private string gioiTinh;
        private string diaChi;
        private string sDT;
        private string cCCD;
        private double luong;

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTenNV { get => hoTenNV; set => hoTenNV = value; }
        public DateTime NTNS { get => nTNS; set => nTNS = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public double Luong { get => luong; set => luong = value; }
    }
}
