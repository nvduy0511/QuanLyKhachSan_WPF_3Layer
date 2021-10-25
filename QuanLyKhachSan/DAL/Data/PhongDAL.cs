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

      
        public List<Phong_Custom> getDataPhongTheoNgay(DateTime? ngayChon)
        {
            
            List<Phong_Custom> ls = new List<Phong_Custom>();

            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                //lấy ra những phòng đang thuê hoặc đã được đặt
                var lsCTPT = db.CT_PhieuThue.Where(p => p.NgayBD <= ngayChon && p.NgayKT >= ngayChon && p.TinhTrangThue.CompareTo("Đã thanh toán") != 0 ).AsEnumerable();
                // join với bảng phòng để lấy ra danh sách phòng nếu phòng nào mà CTPT == null thì phòng đó có nghĩa là trống và ngược lại thì là đã được thuê hoặc đang thuê kết quả ta được 1 list Phòng Custom để hiển thị lên UC_Phong
                ls = (from p in db.Phongs
                      join ct in lsCTPT on p.SoPhong equals ct.SoPhong into t
                      from ct in t.DefaultIfEmpty()
                      select new Phong_Custom()
                      {
                          MaCTPT = ct.MaCTPT,
                          TenKH = (ct.PhieuThue.KhachHang.TenKH == null) ? "" : ct.PhieuThue.KhachHang.TenKH,
                          MaPhong = p.SoPhong,
                          DonDep = p.TinhTrang,
                          TinhTrang = (ct.TinhTrangThue == null) ? "Phòng trống" : ct.TinhTrangThue,
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          SoGio = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("hour", ct.NgayBD, ct.NgayKT)  ,
                          NgayDi = ct.NgayKT,
                          SoNguoi = (ct.SoNguoiO == null) ? 0 : ct.SoNguoiO
                      }).ToList();

            }
            return ls;
        }

        public decimal layGiaTienTheoMaPhong(string soPhong, bool isDay)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                if (isDay == true)
                    return db.Phongs.FirstOrDefault(p => p.SoPhong.Equals(soPhong)).LoaiPhong.GiaNgay;
                else
                    return db.Phongs.FirstOrDefault(p => p.SoPhong.Equals(soPhong)).LoaiPhong.GiaGio;
            }
        }

        public bool suaTinhTrangPhong(string maPhong, string text, out string error)
        {
            error = string.Empty;
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    Phong ph = db.Phongs.FirstOrDefault(p => p.SoPhong.Equals(maPhong));
                    if(ph == null)
                    {
                        error = "Không tồn tại phòng có số phòng: " + maPhong;
                        return false;
                    }
                    else
                    {
                        ph.TinhTrang = text;
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

        //lấy ra giá tiền
        public decimal layGiaTienTheoMaPhong(Phong_Custom phong)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                if(phong.IsDay == true)
                    return db.Phongs.FirstOrDefault(p => p.SoPhong.Equals(phong.MaPhong)).LoaiPhong.GiaNgay;
                else
                    return db.Phongs.FirstOrDefault(p => p.SoPhong.Equals(phong.MaPhong)).LoaiPhong.GiaGio;
            }
        }

        public List<PhongTrong> getPhongTrong(DateTime? ngayBD , DateTime? ngayKT)
        {
            List<PhongTrong> lsPTrong = new List<PhongTrong>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                //lấy ra phòng đã được thuê trong khoảng thời gian chọn được truyền vào
                var lsCTPT = db.CT_PhieuThue.Where(p => (   (p.NgayBD <= ngayBD && p.NgayKT >= ngayKT) || //Trường hợp 1: Ngày được chọn nằm giữ khoảng ngày bắt đầu và ngày kết thúc của phòng đó.
                                                            (p.NgayBD >= ngayBD && p.NgayBD <= ngayKT) || //Trường hợp 2: Ngày được chọn dính vào phần đầu của ngày của phòng.
                                                            (p.NgayKT >= ngayBD && p.NgayKT <= ngayKT) || //Trường hợp 3: Ngày được chọn dính vào phần sau của ngày của phòng.
                                                            (p.NgayBD >= ngayBD && p.NgayKT <= ngayKT) ) && //Trườn hợp 4: Ngày được chọn bao phủ ngày của phòng .
                                                             p.TinhTrangThue.CompareTo("Đã thanh toán") != 0
                                                            ).AsEnumerable();
                //sau khi đã lấy được những phòng đang thuê thì ta ngoại trừ những phòng đó ra ta được những phòng được phép thuê 
                lsPTrong = (from p in db.Phongs
                            where !( from ct in lsCTPT
                                     select ct.SoPhong).Contains(p.SoPhong )
                            select new PhongTrong()
                            { SoPhong = p.SoPhong,
                              TenLoaiPhong= p.LoaiPhong.TenLoaiPhong
                            }).ToList();
            }
            return lsPTrong;
        }

        public List<PhongDTO> getPhong()
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                return (from x in db.Phongs
                        select new PhongDTO()
                        {
                            SoPhong = x.SoPhong,
                            TinhTrang = x.TinhTrang,
                            LoaiPhong = x.LoaiPhong.TenLoaiPhong
                        }).ToList();
            }
        }

        public bool addDataPhong(PhongDTO phong)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    Phong phongMax = db.Phongs.OrderByDescending(n => n.SoPhong).FirstOrDefault();
                    if (phongMax.SoPhong == phong.SoPhong)
                    {
                        return false;
                    }
                    Phong p = new Phong();
                    p.MaLoaiPhong = int.Parse(phong.LoaiPhong.ToString());
                    p.SoPhong = phong.SoPhong;
                    p.TinhTrang = phong.TinhTrang;

                    db.Phongs.Add(p);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void xoaThongTinPhong(PhongDTO phong)
        {
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                var remove = (from p in db.Phongs where p.SoPhong == phong.SoPhong select p).FirstOrDefault();
                if (remove != null)
                {
                    db.Phongs.Remove(remove);
                }
                db.SaveChanges();
            }
        }

        public bool capNhatPhong(PhongDTO phong)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    Phong p = db.Phongs.SingleOrDefault(x => x.SoPhong == phong.SoPhong);
                    if (p == null)
                    {
                        return false;
                    }
                    else
                    {
                        p.TinhTrang = phong.TinhTrang;
                        p.MaLoaiPhong = int.Parse(phong.LoaiPhong.ToString());
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
