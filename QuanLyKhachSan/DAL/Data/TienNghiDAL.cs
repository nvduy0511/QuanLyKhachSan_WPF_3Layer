using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class TienNghiDAL
    {
        private static TienNghiDAL instance;

        public static TienNghiDAL Instance
        {
            get
            {
                if (instance == null) instance = new TienNghiDAL();
                return instance;
            }
        }

        private TienNghiDAL() { }

        public List<TienNghi> getData()
        {
            List<TienNghi> ls = new List<TienNghi>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ls = db.TienNghis.ToList();
            }
            return ls;
        }
        public bool addTienNghi(TienNghi tn)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {

                    db.TienNghis.Add(tn);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool capnhatTienNghi(TienNghi tn)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.Entry(tn).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaTienNghi(TienNghi tn)
        {

            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    var remove = (from s in db.TienNghis where s.MaTN == tn.MaTN select s).FirstOrDefault();
                    if (remove != null)
                    {
                        db.TienNghis.Remove(remove);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool KiemTraTenTienNghi(TienNghi tn)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                TienNghi Check = db.TienNghis.Where(x => x.TenTN.Contains(tn.TenTN)).FirstOrDefault();
                TienNghi tienghi = new TienNghi();
                tienghi.TenTN = Check.TenTN;
                string check1 = String.Concat(tn.TenTN.Where(x => !char.IsWhiteSpace(x))).ToLower();
                string check2 = String.Concat(tienghi.TenTN.Where(x => !char.IsWhiteSpace(x))).ToLower();
                if (check1.Equals(check2))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
