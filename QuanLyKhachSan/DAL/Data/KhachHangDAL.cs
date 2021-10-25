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
        public List<KhachHang> getData()
        {
            List<KhachHang> list = new List<KhachHang>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                list = db.KhachHangs.ToList();
            }
            return list;
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

        public string layTenKhachHangTheoMaPT(int? maPhieuThue)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                PhieuThue pt =  db.PhieuThues.Include("KhachHang").FirstOrDefault(p => p.MaPhieuThue == maPhieuThue );
                if(pt == null)
                {
                    return "Khách vãng lai";
                }
                else
                {
                    return pt.KhachHang.TenKH;
                }
            }
        }

        public bool xoaKhachHang(KhachHang khachHang)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var remove = (from kh in db.KhachHangs where kh.MaKH == khachHang.MaKH select kh).FirstOrDefault();
                if (remove != null)
                {
                    db.KhachHangs.Remove(remove);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool capnhatKhachHang(KhachHang khachHang)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.Entry(khachHang).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
