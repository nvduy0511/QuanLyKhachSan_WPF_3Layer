using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.Data
{
    public class PhieuThueDAL
    {
        private static PhieuThueDAL Instance;

        private PhieuThueDAL()
        {

        }

        public static PhieuThueDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhieuThueDAL();
            }
            return Instance;
        }

        public bool addPhieuThue(PhieuThue pt, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.PhieuThues.Add(pt);
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

        public bool xoaPhieuThueTheoMaPhieuThue(int maPhieuThue, string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    PhieuThue phieuThue = db.PhieuThues.FirstOrDefault(p => p.MaPhieuThue == maPhieuThue);
                    if(phieuThue == null)
                    {
                        error = "Không tồn tại phiếu thuê có mã " + maPhieuThue;
                        return false;
                    }
                    else
                    {
                        db.PhieuThues.Remove(phieuThue);
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

        public List<PhieuThue_Custom> getDataFromDB()
        {
            List<PhieuThue_Custom> ls = new List<PhieuThue_Custom>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ls = (from pt in db.PhieuThues
                      select new PhieuThue_Custom()
                      {
                          MaPhieuThue = pt.MaPhieuThue,
                          NgayLapPhieu = pt.NgayLapPhieu,
                          TenKH = pt.KhachHang.TenKH,
                          TenNV = pt.NhanVien.HoTen
                      }).ToList();
            }
            return ls;

        }
    }
}
