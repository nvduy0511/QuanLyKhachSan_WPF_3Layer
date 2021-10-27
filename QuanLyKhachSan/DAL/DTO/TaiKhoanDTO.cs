using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class TaiKhoanDTO
    {
        string tenTaiKhoan;
        string tenNhanVien;
        int maNV;
        int capDoQuyen;
        string matKhau;

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int CapDoQuyen { get => capDoQuyen; set => capDoQuyen = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
