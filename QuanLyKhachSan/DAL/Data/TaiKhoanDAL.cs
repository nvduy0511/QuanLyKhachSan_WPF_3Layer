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
    }
}
