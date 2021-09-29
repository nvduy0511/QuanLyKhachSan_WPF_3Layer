using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class dNhanVien
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
                db.NhanViens.Add(nv);
                db.SaveChanges();

            }
        }
    }
}
