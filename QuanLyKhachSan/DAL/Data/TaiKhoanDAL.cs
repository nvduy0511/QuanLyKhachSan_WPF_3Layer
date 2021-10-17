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
    }
}
