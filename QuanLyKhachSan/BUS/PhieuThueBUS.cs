using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Data;
using DAL.DTO;

namespace BUS
{
    public class PhieuThueBUS
    {
        private static PhieuThueBUS Instance;

        private PhieuThueBUS()
        {

        }

        public static PhieuThueBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhieuThueBUS();
            }
            return Instance;
        }
        public bool addPhieuThue(PhieuThue ctpt, out string error)
        {
            return PhieuThueDAL.GetInstance().addPhieuThue(ctpt, out error);
        }

        public List<PhieuThue_Custom> getDataPhieuThue()
        {
            return PhieuThueDAL.GetInstance().getDataFromDB();
        }

        public  bool xoaPhieuThueTheoMaPhieuThue(int maPhieuThue, string error)
        {
            return PhieuThueDAL.GetInstance().xoaPhieuThueTheoMaPhieuThue(maPhieuThue, error);
        }

        public int tinhTongSoPhongDatTrongThang(int thang, int nam)
        {
            try
            {
                DateTime dtDauThang = new DateTime(nam, thang, 1);
                DateTime dtCuoiThang = new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1);
                return PhieuThueDAL.GetInstance().tinhTongSoPhongDatTrongThang(dtDauThang, dtCuoiThang);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
