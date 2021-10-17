using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class KhachHangDAL
    {
        private static KhachHangDAL Instance;

        private KhachHangDAL()
        {

        }

        public static KhachHangDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new KhachHangDAL();
            }
            return Instance;
        }

        public bool addKhachHang(KhachHang kh, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        //kiểm tra tồn tại khách hàng

        public KhachHang kiemTraTonTaiKhachHang(string CCCD)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    return db.KhachHangs.FirstOrDefault(p => p.CCCD.Equals(CCCD));
                }
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
