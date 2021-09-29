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
        public static List<Phong_Custom> getDataFromDataBase()
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
                          MaPhong = p.SoPhong.Trim(),
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
    }
}
