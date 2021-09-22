using GUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for uc_QuanLyThongTinKhachHang.xaml
    /// </summary>
    public partial class uc_QuanLyThongTinKhachHang : UserControl
    {
        List<KhachHang> khachHangs = new List<KhachHang>();


        public uc_QuanLyThongTinKhachHang()
        {
            InitializeComponent();
            khachHangs.Add(new KhachHang{ MaNV ="NV01", HoTen ="Phan Vu Loi", CanCuocCongDan ="************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh="nam", QuocTich="Viet Nam" });
            khachHangs.Add(new KhachHang{ MaNV ="NV01", HoTen ="Phan Vu Loi", CanCuocCongDan ="************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh="nam", QuocTich="Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });
            khachHangs.Add(new KhachHang { MaNV = "NV01", HoTen = "Phan Vu Loi", CanCuocCongDan = "************", SoDienThoai = 123456789, DiaChi = "TP.Ho Chi Minh", GioiTinh = "nam", QuocTich = "Viet Nam" });


            lsvKhachHang.ItemsSource = khachHangs;
        }

        private void btnThemKhachHang_Click(object sender, RoutedEventArgs e)
        {
            NhapThongTinKhachHang nhapThongTinKhach = new NhapThongTinKhachHang();
            nhapThongTinKhach.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            CapNhatThongTinKhachHang capNhatThongTinKhach = new CapNhatThongTinKhachHang();
            capNhatThongTinKhach.ShowDialog();
        }
    }

    public class KhachHang
    {
        private string quocTich;
        private string gioiTinh;
        private string diaChi;
        private int soDienThoai;
        private string canCuocCongDan;
        private string hoTen;
        private string maNV;

       
        public string CanCuocCongDan { get => canCuocCongDan; set => canCuocCongDan = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string QuocTich { get => quocTich; set => quocTich = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string MaNV { get => maNV; set => maNV = value; }
    }

}
