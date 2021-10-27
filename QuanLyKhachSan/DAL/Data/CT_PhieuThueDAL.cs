using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CT_PhieuThueDAL
    {
        private static CT_PhieuThueDAL Instance;

        private CT_PhieuThueDAL()
        {

        }

        public static CT_PhieuThueDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CT_PhieuThueDAL();
            }
            return Instance;
        }
        public bool addCTPhieuThue(CT_PhieuThue ctpt , out string error)
        {

            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.CT_PhieuThue.Add(ctpt);
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

        public bool suaTinhTrangThuePhong(int? maCTPT, string tinhtrangthuephong, out string error)
        {
            error = string.Empty;
            if(maCTPT == null)
            {
                error = "Không tồn tại mã chi tiết phiếu thuê";
                return false;
            }
            else
            {
                try
                {
                    using (QLKhachSanEntities db = new QLKhachSanEntities())
                    {
                        CT_PhieuThue ct = db.CT_PhieuThue.FirstOrDefault(p => p.MaCTPT == maCTPT);
                        if(ct == null)
                        {
                            error = "Không tồn tại chi tiết phiếu thuê có mã: " + maCTPT;
                            return false;
                        }
                        else
                        {
                            ct.TinhTrangThue = tinhtrangthuephong;
                            db.SaveChanges();
                            return true;

                        }
                    }

                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public decimal tinhDoanhThuTheoThang(DateTime dtDauThang, DateTime dtCuoiThang)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                decimal? tongTienPhong = db.CT_PhieuThue.Where(p => dtDauThang<= p.NgayTraThucTe && dtCuoiThang>= p.NgayTraThucTe).Sum(p => p.TienPhong);
                return tongTienPhong == null ? 0 : tongTienPhong.Value;
            }
        }

        public bool capNhatTienVaNgayTraThucTe(int? maCTPT, decimal? tienPhong, DateTime now, out string errorCapNhatCTPT)
        {
            errorCapNhatCTPT = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    CT_PhieuThue ct = db.CT_PhieuThue.FirstOrDefault(p => p.MaCTPT == maCTPT);
                    if (ct == null)
                    {
                        errorCapNhatCTPT = "Không tồn tại chi tiết phiếu thuê có mã: " + maCTPT;
                        return false;
                    }
                    else
                    {
                        ct.TienPhong = tienPhong;
                        ct.NgayTraThucTe = now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCapNhatCTPT = ex.Message; 
                return false;
            }
        }


        public List<CT_PhieuThue> getPhieuThueTheoMaPT(int maPT)
        {
            List<CT_PhieuThue> ls = new List<CT_PhieuThue>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ls = db.CT_PhieuThue.Where(p => p.MaPhieuThue == maPT).ToList();
            }
            return ls;
        }
    }
}
