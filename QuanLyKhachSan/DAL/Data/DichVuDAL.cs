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


    }
}
