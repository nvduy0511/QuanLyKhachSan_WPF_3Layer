using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class HoaDonDAL
    {
        private static HoaDonDAL Instance;

        private HoaDonDAL()
        {

        }

        public static HoaDonDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new HoaDonDAL();
            }
            return Instance;
        }


        public List<HoaDonDTO> LayDuLieuHoaDon()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from s in db.HoaDons
                        select new HoaDonDTO()
                        {
                            MaHoaDon = s.MaHD,
                            NgayLap = s.NgayLap,
                            TongTien = s.TongTien,
                            TenNHanVienLap = s.NhanVien.HoTen,
                            MaCTPhieuThue = s.MaCTPT.Value
                        }).ToList();
            }

        }

        public List<HoaDonDTO> layHoaDonTheoThangNam(DateTime dtDauThang, DateTime dtCuoiThang)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from s in db.HoaDons
                        where s.NgayLap >= dtDauThang && s.NgayLap<=dtCuoiThang
                        select new HoaDonDTO()
                        {
                            MaHoaDon = s.MaHD,
                            NgayLap = s.NgayLap,
                            TongTien = s.TongTien,
                            TenNHanVienLap = s.NhanVien.HoTen,
                            MaCTPhieuThue = s.MaCTPT.Value
                        }).ToList();
            }

        }

        public HoaDon layHoaDonTheoMaHoaDon(int mahd)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    return db.HoaDons.Include("NhanVien").Include("CT_PhieuThue").FirstOrDefault(p => p.MaHD == mahd);
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool themHoaDon(HoaDon hd, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.HoaDons.Add(hd);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }


    }
}
