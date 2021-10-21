using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CT_TienNghiDAL
    {
        private static CT_TienNghiDAL instance;

        public static CT_TienNghiDAL Instance
        {
            get
            {
                if (instance == null) instance = new CT_TienNghiDAL();
                return instance;
            }
        }

        private CT_TienNghiDAL() { }

        public List<CT_TienNghiDTO> getData()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from ct in db.CT_TienNghi
                        select new CT_TienNghiDTO()
                        {
                            MaCT = ct.MaCTTN,
                            SoPhong = ct.SoPhong,
                            TenTN = ct.TienNghi.TenTN,
                            SoLuong = ct.SL
                        }).ToList();
            }
        }
        public bool addCTTienNghi(CT_TienNghiDTO chiTietTN)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {

                    CT_TienNghi ct = new CT_TienNghi();

                    ct.SoPhong = chiTietTN.SoPhong;
                    ct.MaTN = int.Parse(chiTietTN.TenTN.ToString());
                    ct.SL = chiTietTN.SoLuong;
                    db.CT_TienNghi.Add(ct);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool capnhatCTTienNghi(CT_TienNghiDTO chiTietTN)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    CT_TienNghi tn = db.CT_TienNghi.SingleOrDefault(x => x.MaCTTN == chiTietTN.MaCT);
                    if (tn == null)
                    {
                        return false;
                    }
                    else
                    {
                        tn.SoPhong = chiTietTN.SoPhong;
                        tn.SL = chiTietTN.SoLuong;
                        tn.MaTN = int.Parse(chiTietTN.TenTN.ToString());
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaCTTienNghi(CT_TienNghiDTO chiTietTN)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    var remove = (from p in db.CT_TienNghi where p.MaCTTN == chiTietTN.MaCT select p).FirstOrDefault();
                    if (remove != null)
                    {
                        db.CT_TienNghi.Remove(remove);
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

        public bool KiemTraTonTai(CT_TienNghiDTO cttn)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                int maTN = int.Parse(cttn.TenTN);
                CT_TienNghi Check = db.CT_TienNghi.Where(x => x.MaTN == maTN && x.SoPhong.Contains(cttn.SoPhong)).FirstOrDefault();
                if(Check == null)
                {
                    return true;
                }
                else
                {
                    CT_TienNghi tienghi = new CT_TienNghi();
                    tienghi.MaTN = Check.MaTN;
                    if (tienghi.MaTN == maTN)
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
