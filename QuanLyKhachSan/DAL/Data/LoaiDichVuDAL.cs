using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class LoaiDichVuDAL
    {
        private static LoaiDichVuDAL instance;

        public static LoaiDichVuDAL Instance
        {
            get
            {
                if (instance == null) instance = new LoaiDichVuDAL();
                return instance;
            }
        }

        private LoaiDichVuDAL() { }

        public List<LoaiDV> getData()
        {
            List<LoaiDV> list = new List<LoaiDV>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                list = db.LoaiDVs.ToList();
            }
            return list;
        }

        public bool addDataLoaiDV(LoaiDV loaiDV)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    LoaiDV loaiDVMax = db.LoaiDVs.OrderByDescending(n => n.MaLoaiDV).FirstOrDefault();

                    db.LoaiDVs.Add(loaiDV);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool xoaLoaiDV(LoaiDV loaiDV)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    var remove = (from k in db.LoaiDVs where k.MaLoaiDV == loaiDV.MaLoaiDV select k).FirstOrDefault();
                    if (remove != null)
                    {
                        db.LoaiDVs.Remove(remove);
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool capnhatLoaiDV(LoaiDV loaiDV)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.Entry(loaiDV).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool KiemTraTenLoaiDichVu(LoaiDV loaiDV)
        {
            using(QLKhachSanEntities db = new QLKhachSanEntities())
            {
                LoaiDV Check = db.LoaiDVs.Where(x => x.TenLoaiDV.Contains(loaiDV.TenLoaiDV)).FirstOrDefault();
                if(Check == null)
                {
                    return true;
                }
                LoaiDV ldv = new LoaiDV();
                ldv.TenLoaiDV = loaiDV.TenLoaiDV;
                ldv.MaLoaiDV = int.Parse(loaiDV.MaLoaiDV.ToString());
                string check1 = String.Concat(loaiDV.TenLoaiDV.Where(x => !char.IsWhiteSpace(x))).ToLower();
                string check2 = String.Concat(ldv.TenLoaiDV.Where(x => !char.IsWhiteSpace(x))).ToLower();
                if (check1.Equals(check2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
