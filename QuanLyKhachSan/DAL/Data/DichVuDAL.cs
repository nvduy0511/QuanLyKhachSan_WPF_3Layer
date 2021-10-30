using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.Data
{
    public class DichVuDAL
    {
        private static DichVuDAL Instance;

        private DichVuDAL()
        {

        }

        public static DichVuDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DichVuDAL();
            }
            return Instance;
        }

        public List<DichVu_Custom> getDataDichVu_Custom()
        {
            List<DichVu_Custom> lsNDVCT = new List<DichVu_Custom>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                lsNDVCT = (from dv in db.DichVus
                          select new DichVu_Custom()
                          {
                              Gia = dv.Gia,
                              LoaiDV = dv.LoaiDV.TenLoaiDV,
                              TenDV = dv.TenDV,
                              MaDV = dv.MaDV

                          }).ToList();
            }
            return lsNDVCT;
        }
        public List<string> getDataLoaiDichVu()
        {
            List<string> lsLoaiDV = new List<string>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                lsLoaiDV = (from ldv in db.LoaiDVs
                            select ldv.TenLoaiDV).ToList();
            }
            
            return lsLoaiDV;
        }

        public List<DichVuDTO> getDataDichVu()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from dv in db.DichVus
                        select new DichVuDTO()
                        {
                            MaDichVu = dv.MaDV,
                            TenDichVu = dv.TenDV,
                            LoaiDichVu = dv.LoaiDV.TenLoaiDV,
                            Gia = dv.Gia

                        }).ToList();
            }
        }

        public bool addDichVu(DichVuDTO dv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    DichVu dichvu = new DichVu();
                    dichvu.TenDV = dv.TenDichVu;
                    dichvu.MaLoaiDV = int.Parse(dv.LoaiDichVu.ToString());
                    dichvu.Gia = dv.Gia;
                    
                    db.DichVus.Add(dichvu);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void xoaDichVu(DichVuDTO dv)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var remove = (from p in db.DichVus where p.MaDV == dv.MaDichVu select p).FirstOrDefault();
                if (remove != null)
                {
                    db.DichVus.Remove(remove);
                }
                db.SaveChanges();
            }
        }

        public bool capNhatDichVu(DichVuDTO dv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    DichVu dichvu = db.DichVus.SingleOrDefault(x => x.MaDV == dv.MaDichVu);
                    if (dichvu == null)
                    {
                        return false;
                    }
                    else
                    {
                        dichvu.TenDV = dv.TenDichVu;
                        dichvu.MaLoaiDV = int.Parse(dv.LoaiDichVu.ToString());
                        dichvu.Gia = dv.Gia;
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

        public bool KiemTraTrungTen(DichVuDTO dv)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                DichVu Check = db.DichVus.Where(x => x.TenDV.Contains(dv.TenDichVu)).FirstOrDefault();
                if(Check == null)
                {
                    return true;
                }
                else
                {
                    DichVu dichvu = new DichVu();
                    dichvu.TenDV = Check.TenDV;
                    string check1 = String.Concat(dv.TenDichVu.Where(x => !char.IsWhiteSpace(x))).ToLower();
                    string check2 = String.Concat(dichvu.TenDV.Where(x => !char.IsWhiteSpace(x))).ToLower();
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
