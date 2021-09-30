using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Data
{
    public class NhanVienDAL
    {
        public static List<NhanVien> getDataNhanVien()
        {
            List<NhanVien> lsNV = new List<NhanVien>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                lsNV = db.NhanViens.ToList();
                
            }
            return lsNV;
        }
        public static void addDataNhanVien(NhanVien nv)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                NhanVien nvMax = db.NhanViens.OrderByDescending(n => n.MaNV).FirstOrDefault();
                
                db.NhanViens.Add(nv);
                db.SaveChanges();
            }
        }
        public static string getMaxMaNV()
        {
            NhanVien nvMax;
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                nvMax = db.NhanViens.OrderByDescending(n => n.MaNV).FirstOrDefault();

            }
            return nvMax.MaNV;
        }
    }
}
