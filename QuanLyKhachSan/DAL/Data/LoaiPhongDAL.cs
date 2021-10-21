using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class LoaiPhongDAL
    {
        private static LoaiPhongDAL instance;

        public static LoaiPhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new LoaiPhongDAL();
                return instance;
            }
        }

        private LoaiPhongDAL() { }

        public List<LoaiPhong> getDataLoaiPhong()
        {
            List<LoaiPhong> ls = new List<LoaiPhong>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ls = db.LoaiPhongs.ToList();
            }
            return ls;
        }

        public bool addLoaiPhong(LoaiPhong loaiPhong)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    LoaiPhong LPMax = db.LoaiPhongs.OrderByDescending(n => n.MaLoaiPhong).FirstOrDefault();

                    db.LoaiPhongs.Add(loaiPhong);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool capnhatLoaiPhong(LoaiPhong loaiPhong)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.Entry(loaiPhong).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaLoaiPhong(LoaiPhong loaiPhong)
        {

            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    var remove = (from lp in db.LoaiPhongs where lp.MaLoaiPhong == loaiPhong.MaLoaiPhong select lp).FirstOrDefault();
                    if (remove != null)
                    {
                        db.LoaiPhongs.Remove(remove);
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

        public bool KiemTraTenLoaiPhong(LoaiPhong loaiPhong)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                LoaiPhong Check = db.LoaiPhongs.Where(x => x.TenLoaiPhong.Equals(loaiPhong.TenLoaiPhong)).FirstOrDefault();
                if(Check == null)
                {
                    return true;
                }
                else
                {
                    LoaiPhong lp = new LoaiPhong();
                    lp.TenLoaiPhong = Check.TenLoaiPhong;
                    string check1 = String.Concat(loaiPhong.TenLoaiPhong.Where(x => !char.IsWhiteSpace(x))).ToLower();
                    string check2 = String.Concat(lp.TenLoaiPhong.Where(x => !char.IsWhiteSpace(x))).ToLower();
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
}
