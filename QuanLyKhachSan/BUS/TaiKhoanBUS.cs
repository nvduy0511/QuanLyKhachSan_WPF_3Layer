using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Data;
using DAL.DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS Instance;

        private TaiKhoanBUS()
        {

        }

        public static TaiKhoanBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TaiKhoanBUS();
            }
            return Instance;
        }
        public TaiKhoan kiemTraTKTonTaiKhong(string username, string pass)
        {
            string matKhau = MD5_HashBUS.GetInstance().HashMatKhauThanhMD5(pass);

            return TaiKhoanDAL.GetInstance().layTaiKhoanTuDataBase(username, matKhau);
        }
        public bool capNhatAvatar(string username,string avatar, out string error)
        {
            return TaiKhoanDAL.GetInstance().capNhatAvatar( username , avatar, out error);
        }

        public bool themTaiKhoan(TaiKhoan tk, out string error)
        {
            error = string.Empty;
            if (TaiKhoanDAL.GetInstance().kiemTraTaiKhoanTonTai(tk.username))
            {
                error = "Tài khoản đã tồn tại vui lòng nhập tài khoản khác !";
                return false;
            }
            tk.password = MD5_HashBUS.GetInstance().HashMatKhauThanhMD5(tk.password);
            return TaiKhoanDAL.GetInstance().themTaiKhoan(tk, out error);
        }

        public List<TaiKhoanDTO> layDanhSachTaiKhoan()
        {
            return TaiKhoanDAL.GetInstance().layDanhSachTaiKhoan();
        }

        public bool xoaTaiKhoan(TaiKhoanDTO tk, out string error)
        {
            return TaiKhoanDAL.GetInstance().xoaTaiKhoan(tk, out error);
        }

        public List<int> layDanhSachNhanVienChuaCoTaiKhoan()
        {
            return TaiKhoanDAL.GetInstance().layDanhSachNhanVienChuaCoTaiKhoan();
        }

        public bool suaTaiKhoan(TaiKhoan taiKhoanCapNhat, out string error)
        {
            taiKhoanCapNhat.password = MD5_HashBUS.GetInstance().HashMatKhauThanhMD5(taiKhoanCapNhat.password);
            return TaiKhoanDAL.GetInstance().suaTaiKhoan(taiKhoanCapNhat, out error);
        }
    }
}
