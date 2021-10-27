using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL Instance;

        private TaiKhoanDAL()
        {

        }

        public static TaiKhoanDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TaiKhoanDAL();
            }
            return Instance;
        }

        public TaiKhoan layTaiKhoanTuDataBase(string username , string pass)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return db.TaiKhoans.Include("NhanVien"). FirstOrDefault(p => p.username.Equals(username) && p.password.Equals(pass));
            }
        }

        public bool capNhatAvatar(string username, string avatar, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    TaiKhoan tk = db.TaiKhoans.FirstOrDefault(p => p.username.Equals(username));
                    if (tk == null)
                    {
                        error = "Không tồn tại tài khoản " + username;
                        return false;
                    }
                    else
                    {
                        tk.avatar = avatar;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            

        }

        public List<TaiKhoanDTO> layDanhSachTaiKhoan()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from tk in db.TaiKhoans
                        select new TaiKhoanDTO()
                        {
                            CapDoQuyen = tk.CapDoQuyen,
                            MaNV = tk.MaNV,
                            MatKhau = tk.password,
                            TenNhanVien = tk.NhanVien.HoTen,
                            TenTaiKhoan = tk.username
                        }).ToList();
            }
        }

        public bool xoaTaiKhoan(TaiKhoanDTO tk, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.username.Equals(tk.TenTaiKhoan));
                    if(taiKhoan == null)
                    {
                        error = "Không tồn tại tài khoản!";
                        return false;
                    }
                    else
                    {
                        db.TaiKhoans.Remove(taiKhoan);
                        db.SaveChanges();
                        return true;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool suaTaiKhoan(TaiKhoan taiKhoanCapNhat, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    var taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.username.Equals(taiKhoanCapNhat.username));
                    if(taiKhoan == null)
                    {
                        error = "Không tồn tại tài khoản "+taiKhoanCapNhat.username;
                        return false;
                    }
                    else
                    {
                        taiKhoan.password = taiKhoanCapNhat.password;
                        taiKhoan.CapDoQuyen = taiKhoanCapNhat.CapDoQuyen;
                        db.SaveChanges();
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool themTaiKhoan(TaiKhoan tk, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.TaiKhoans.Add(tk);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool kiemTraTaiKhoanTonTai(string taikhoan)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var taiKhoan = db.TaiKhoans.Include("NhanVien").FirstOrDefault(p => p.username.Equals(taikhoan));
                if(taiKhoan == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public List<int> layDanhSachNhanVienChuaCoTaiKhoan()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var nvDaCoTK = db.TaiKhoans.AsEnumerable();
                return (from nv in db.NhanViens
                        where !(from nvdc in nvDaCoTK
                                select nvdc.MaNV).Contains(nv.MaNV)
                        select nv.MaNV).ToList();
            }
        }
    }
}
