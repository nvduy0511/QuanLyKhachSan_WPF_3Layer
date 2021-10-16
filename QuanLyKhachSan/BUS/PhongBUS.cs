using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL;
using DAL.Data;

namespace BUS
{
    public class PhongBUS
    {
        private static PhongBUS Instance;

        private PhongBUS()
        {

        }

        public static PhongBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhongBUS();
            }
            return Instance;
        }
        

        public List<Phong_Custom> getDataPhongCustomTheoNgay(DateTime? ngayChon)
        {
            return PhongDAL.GetInstance().getDataPhongTheoNgay(ngayChon);
        }

        public List<PhongTrong> getPhongTrong(DateTime? ngayBD, DateTime? ngayKT)
        {
            return PhongDAL.GetInstance().getPhongTrong(ngayBD,ngayKT);
        }
        public decimal? tinhTienPhong(Phong_Custom phong)
        {
            decimal? tienPhong;
            tienPhong = PhongDAL.GetInstance().layGiaTienTheoMaPhong(phong);
            if(phong.IsDay== true)
            {
                return phong.SoNgayO * tienPhong;
            }
            else
            {
                return phong.SoGio * tienPhong;
            }
        }
        public decimal layTienPhongTheoSoPhong(Phong_Custom phong)
        {
            return PhongDAL.GetInstance().layGiaTienTheoMaPhong(phong);
        }

        public bool suaTinhTrangDonDep(string maPhong, string text, out string error)
        {
            return PhongDAL.GetInstance().suaTinhTrangPhong(maPhong, text, out error);
        }
    }
}
