using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Data
{
    public class NhanVienDAL
    {
        private static NhanVienDAL Instance;

        private NhanVienDAL()
        {

        }

        public static NhanVienDAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new NhanVienDAL();
            }
            return Instance;
        }

        //Lấy danh sách nhân viên từ DB
        public List<NhanVien> getDataNhanVien()
        {
            List<NhanVien> lsNV = new List<NhanVien>();
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                lsNV = db.NhanViens.ToList();
                
            }
            return lsNV;
        }
        //Thêm mới nhân viên
        public bool addDataNhanVien(NhanVien nv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        //Sửa nhân viên
        public bool updateDataNhanVien(NhanVien nv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                // cách củ chuối
                    //var u_NhanVien = db.NhanViens.Find(nv.MaNV);
                    //u_NhanVien.HoTen = nv.HoTen;
                    //u_NhanVien.GioiTinh = nv.GioiTinh;
                    //u_NhanVien.NTNS = nv.NTNS;
                    //u_NhanVien.Luong = nv.Luong;
                    //u_NhanVien.SDT = nv.SDT;
                    //u_NhanVien.CCCD = nv.CCCD;
                    //u_NhanVien.ChucVu = nv.ChucVu;
                    //u_NhanVien.DiaChi = nv.DiaChi;
                //cách Vip hơn tí
                    db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Xóa nhân viên
        public bool deleteDataNhanVien(NhanVien nv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.Entry(nv).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        //Lấy ra mã nhân viên lớn nhất
        public string getMaxMaNV()
        {
            NhanVien nvMax;
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                nvMax = db.NhanViens.OrderByDescending(n => n.MaNV).FirstOrDefault();

            }
            return nvMax.MaNV;
        }
    }
}
