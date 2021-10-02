using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using System.Data.Entity.SqlServer;

namespace DAL.Data
{
    public class PhongDAL
    {
        private static PhongDAL Instance;

        private PhongDAL()
        {

        }

        public static PhongDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhongDAL();
            }
            return Instance;
        }

        public List<Phong_Custom> getDataFromDataBase()
        {
            List < Phong_Custom > ls = new List<Phong_Custom>();
            using( QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ls = (from p in db.Phongs
                      join ct in db.CT_PhieuThue on p.SoPhong equals ct.SoPhong into t
                      from ct in t.DefaultIfEmpty()
                      select new Phong_Custom()
                      {
                          TenKH = (ct.PhieuThue.KhachHang.TenKH == null) ? "" : ct.PhieuThue.KhachHang.TenKH,
                          MaPhong = p.SoPhong,
                          DonDep = p.TinhTrang,
                          TinhTrang = (ct.TinhTrangThue == null) ? "Phòng trống" : ct.TinhTrangThue,
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD,ct.NgayKT),
                          SoNguoi = (ct.SoNguoiO == null) ? 0: ct.SoNguoiO
                      }).ToList();
                         

            }
            return ls;
        }
        public List<Phong_Custom> getDataPhongTheoNgay(DateTime? ngayChon)
        {
            
            List<Phong_Custom> ls = new List<Phong_Custom>();

            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var lsCTPT = db.CT_PhieuThue.Where(p => p.NgayBD <= ngayChon && p.NgayKT >= ngayChon).AsEnumerable();

                ls = (from p in db.Phongs
                      join ct in lsCTPT on p.SoPhong equals ct.SoPhong into t
                      from ct in t.DefaultIfEmpty()
                      select new Phong_Custom()
                      {
                          TenKH = (ct.PhieuThue.KhachHang.TenKH == null) ? "" : ct.PhieuThue.KhachHang.TenKH,
                          MaPhong = p.SoPhong,
                          DonDep = p.TinhTrang,
                          TinhTrang = (ct.TinhTrangThue == null) ? "Phòng trống" : ct.TinhTrangThue,
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          SoNguoi = (ct.SoNguoiO == null) ? 0 : ct.SoNguoiO
                      }).ToList();

            }
            return ls;
        }


        public List<PhongTrong> getPhongTrong()
        {
            List<PhongTrong> lsPTrong = new List<PhongTrong>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                lsPTrong = (from p in db.Phongs
                            where !(from ct in db.CT_PhieuThue
                                    select ct.SoPhong).Contains(p.SoPhong)
                            select new PhongTrong()
                            { SoPhong = p.SoPhong,
                              TenLoaiPhong= p.LoaiPhong.TenLoaiPhong
                            }).ToList();
            }
            return lsPTrong;
        }


    }
}
