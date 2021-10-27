using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DTO;
namespace DAL.Data
{
    public class CTSDDV_DAL
    {
        private static CTSDDV_DAL Instance;

        private CTSDDV_DAL()
        {

        }

        public static CTSDDV_DAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CTSDDV_DAL();
            }
            return Instance;
        }
        //Thêm mới chi tiết sử dụng dịch vụ
        public bool addDataCTSDDC(CT_SDDichVu ctsddv , out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.CT_SDDichVu.Add(ctsddv);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }

        }

        public List<decimal> tongTienChiTietSuDungDichVu(int? maCTPT)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from ct in db.CT_SDDichVu
                        where ct.MaCTPT == maCTPT
                        select ct.ThanhTien).ToList();
            }
        }

        //Lấy danh sách sử dụng dịch vụ của 1 phòng nào đó dựa vào mã CTPT
        public List<DichVu_DaChon> getCTSDDVtheoMaCTPT(int? maCTPT)
        {
            List<DichVu_DaChon> ls = new List<DichVu_DaChon>();
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    ls = (from ct in db.CT_SDDichVu
                          where ct.MaCTPT == maCTPT
                          select new DichVu_DaChon()
                          {
                              ThanhTien = ct.ThanhTien,
                              MaDV = ct.MaDV,
                              TenDV = ct.DichVu.TenDV,
                              SoLuong = ct.SL,
                              Gia = ct.DichVu.Gia

                          }).ToList();
                }
                return ls;
            }
            catch (Exception )
            {
                return ls;
            }
        }

        public decimal tinhDoanhThuTheoThang(DateTime dtDauThang, DateTime dtCuoiThang)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                decimal? tongTienDV = db.CT_SDDichVu.Where(p => dtDauThang <= p.CT_PhieuThue.NgayTraThucTe
                                            && dtCuoiThang >= p.CT_PhieuThue.NgayTraThucTe).Sum(p=> p.ThanhTien);

                return tongTienDV == null ? 0 : tongTienDV.Value;
            }
        }
    }
}
